using Microsoft.AspNetCore.Mvc;

namespace PublisherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetTest")]
        public string Get()
        {
            _logger.LogInformation("PublisherAPI/Test");
            return "Response from PublisherAPI!";
        }
    }
}