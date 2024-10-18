using Microsoft.AspNetCore.Mvc;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> ListWeatherForecast = new List<WeatherForecast>();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;

            if (ListWeatherForecast == null || !ListWeatherForecast.Any())
            {
                ListWeatherForecast = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                }).ToList();
            }
        }

        [HttpGet(Name = "GetWeatherForecast")]
        //[Route("Get/weatherforecast")]
        //[Route("Get/weatherforecast2")]
        //[Route("[action]")]
        public IEnumerable<WeatherForecast> GetW()
        {
            _logger.LogInformation("Retornando la lista de WheatherForecast");
            return ListWeatherForecast;
        }

        [HttpGet]
        [Route("Get/weatherforecast/{index}")]
        public WeatherForecast Get(int index)
        {
            return ListWeatherForecast[index];
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast weatherForecast)
        {
            ListWeatherForecast.Add(weatherForecast);

            return Ok();
        }

        [HttpDelete("{index}")]
        public IActionResult Delete(int index) 
        { 
            ListWeatherForecast.RemoveAt(index);

            return Ok();
        }
    }
}
