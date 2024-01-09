using System.Text;
using System.Text.Json;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace PublisherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishTestController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public PublishTestController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPublishTest")]
        public async Task<string> Get()
        {
            _logger.LogInformation("PublisherAPI/PublishTest");

            var data = "This is message from PublisherAPI!";

            using var client = new DaprClientBuilder().Build();
            await client.PublishEventAsync<string>("order-queue", "test", data);

            return "Published data: " + data;
        }
    }
}
