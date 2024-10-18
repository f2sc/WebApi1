using Microsoft.AspNetCore.Mvc;
using projectEF;
using WebApi1.Service;

namespace WebApi1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HelloWorldController : ControllerBase
    {
        IHelloWorldService helloWorldService;

        private readonly ILogger<WeatherForecastController> _logger;

        TareasContext context;
        public HelloWorldController(IHelloWorldService helloWorld, ILogger<WeatherForecastController> logger, TareasContext dbContext)
        {
            _logger = logger;
            helloWorldService = helloWorld;
            context = dbContext;
        }

        [HttpGet]
        public IActionResult Get()
        {
            _logger.LogInformation("Recuperando la lista de HelloWorld.");
            return Ok(helloWorldService.GetHelloWorld());
        }

        [HttpGet]
        [Route("createdb")]
        public IActionResult CreateDatabase()
        {
            context.Database.EnsureCreated();
            return Ok();
        }
    }
}
