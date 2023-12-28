using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace PlayingWithSerialization.Api.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger) {
            _logger = logger;
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get() {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = (WeatherSummary)Random.Shared.Next(0, 10)
            })
            .ToArray();
        }

        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost(Name = nameof(PostWeatherForecast))]
        public ActionResult PostWeatherForecast([FromBody]WeatherForecast forecast) {
            if(ModelState.IsValid) {
                return CreatedAtAction(nameof(Get), new { id = 0 }, forecast);
            }
            return BadRequest(ModelState);
        }
    }
}
