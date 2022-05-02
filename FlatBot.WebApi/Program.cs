using FlatBot.Application;
using FlatBot.Application.Services;
using FlatBot.Infrastructure;
using FlatBot.Persistance;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGet("/CheckWebHealth", () => "I`m ok");
app.MapGet("/CheckMongoHealth", async (IHealthService healthService) =>
    await healthService.CheckHealthAsync() ? Results.Ok("I`m ok") : Results.BadRequest("I`m not ok(("));

app.MapGet("/Olx", async (IOLXService iOLXService) =>
    await iOLXService.GetOLXData());


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
