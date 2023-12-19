using System.Text;
using System.Text.Json;
using Dapr.Client;
using Microsoft.AspNetCore.Mvc;

namespace PublisherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PublishOrderController : Controller
    {
        private readonly ILogger<TestController> _logger;

        public PublishOrderController(ILogger<TestController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPublishOrder")]
        public async Task<string> Get()
        {
            _logger.LogInformation("PublisherAPI/PublishOrder-Started");

            var data = Guid.NewGuid().ToString();

            using var client = new DaprClientBuilder().Build();
            await client.PublishEventAsync<string>("order-queue", "newOrders", data);

            _logger.LogInformation($"PublisherAPI/PublishOrder-Finished [guid:{data}]");
            return "Published data: " + data;
        }
    }
}
