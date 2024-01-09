using Dapr.Client;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using SubscriberAPI.Workflows;

namespace SubscriberAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;

        public TestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async void Post([FromBody] CloudEvent<string> cloudEvent)
        {
            var msg = cloudEvent.Data;
            _logger.LogInformation($"SubscriberAPI/Test [{msg}]");

        }
    }
}
