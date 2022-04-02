using FlatBot.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace FlatBot.WebApi.Controllers
{
    [ApiController]
    [Route("Health")]
    public class HealthCheckControllers : ControllerBase
    {
        private readonly IHealthService _healthService;

        public HealthCheckControllers(IHealthService healthService)
        {
            _healthService = healthService;
        }

        [Route("CheckWebHealth")]
        [HttpGet]
        public IActionResult CheckWebHealth()
        {
            return Ok("I`m ok");
        }

        [Route("CheckMongoHealth")]
        [HttpGet]
        public async Task<IActionResult> CheckMongHealth()
        {
            return await _healthService.CheckHealthAsync() ? Ok("I`m ok") : BadRequest("I`m not ok((");
        }
    }
}
