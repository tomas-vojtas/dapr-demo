using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapr;
using Dapr.Client;
using System.Text;

namespace SubscriberAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;

        public OrderController(ILogger<OrderController> logger)
        {
            _logger = logger;
        }

        [Topic("order-queue", "newOrders")]
        [HttpPost]
        public async void Post([FromBody] CloudEvent<string> cloudEvent)
        {
            // string rawContent = string.Empty;
            // using (var reader = new StreamReader(Request.Body,
            //            encoding: Encoding.UTF8, detectEncodingFromByteOrderMarks: false))
            // {
            //     rawContent = await reader.ReadToEndAsync();
            // }
            _logger.LogInformation($"SubscriberAPI/Order-{cloudEvent.Data}");
            //return data;
        }
    }
}
