using Microsoft.AspNetCore.Mvc;
using Project.Core.Caching.Attributes;
using Project.Core.Model;

namespace Project.TestService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
        
        [HttpPost(Name = "GetWeatherForecast")]
        
        public IActionResult Get([FromBody] JWTOptions wTOptions)
        {
            return Ok(wTOptions);
        }
    }
}