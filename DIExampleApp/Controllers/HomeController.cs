using Microsoft.AspNetCore.Mvc;

namespace DiExampleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IGreetingService _greetingService;

        public HomeController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var greeting = _greetingService.Greet("World from controller");
            return Ok(greeting);
        }
    }
}
