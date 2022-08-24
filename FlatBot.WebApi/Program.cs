using FlatBot.Application;
using FlatBot.Application.Services;
using FlatBot.Infrastructure;
using FlatBot.Persistance;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Logging.ClearProviders();
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();
builder.Logging.AddSerilog(logger);

var app = builder.Build();

app.MapGet("/", (ICitiesManagementService service) => service.TestFunc());
app.MapGet("/CheckWebHealth", () => "I`m ok");
app.MapGet("/CheckMongoHealth", async (IHealthService healthService) =>
    await healthService.CheckHealthAsync() ? Results.Ok("I`m ok") : Results.BadRequest("I`m not ok(("));

app.MapGet("/Olx", async (IOLXService iOLXService) =>
    await iOLXService.GetOLXData(new FlatBot.Domain.Entities.OlxSearchParameters()));


if (app.Environment.IsDevelopment() || app.Environment.EnvironmentName == "Docker")
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.Run();
