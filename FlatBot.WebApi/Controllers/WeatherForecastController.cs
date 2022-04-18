using FlatBot.Application.Services;
using FlatBot.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;

namespace FlatBot.WebApi.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]")]
    //[RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IOLXService _iOLXService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IOLXService iOLXService)
        {
            _logger = logger;
            _iOLXService = iOLXService;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task GetAsync()
        {
            await _iOLXService.GetOLXData();

        }
    }
}