using FlatBot.Application.Services;

namespace FlatBot.WebApi.Endpoints
{
    public static class HealthCheckEndpoints
    {
        public static void MapHealthCheckEndpoints(this WebApplication app)
        {
            app.MapGet("/CheckWebHealth", () => "I`m okay");
            app.MapGet("/CheckMongoHealth", async (IHealthService healthService) =>
                await healthService.CheckHealthAsync() ? Results.Ok("I`m good") : Results.BadRequest("I`m not ok(("));
        }
    }
}
