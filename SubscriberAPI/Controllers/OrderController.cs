using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Dapr;
using Dapr.Client;
using System.Text;
using SubscriberAPI.Workflows;
using static Dapr.Client.Autogen.Grpc.v1.Dapr;
using DaprClient = Dapr.Client.DaprClient;

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

        //[Topic("order-queue", "newOrders")]
        // Unnecessary - alternative to declaration in subscription.yaml
        [HttpPost]
        public async void Post([FromBody] CloudEvent<string> cloudEvent)
        {
            var guid = cloudEvent.Data;
            _logger.LogInformation($"SubscriberAPI/Order-Started [guid:{guid}]");
            Console.WriteLine($"Starting order workflow '{guid}'");
            DaprClient client = new DaprClientBuilder().Build();
            await client.StartWorkflowAsync(
                workflowComponent: "dapr", // Very likely very wrong
                workflowName: nameof(OrderProcessingWorkflow),
                input: guid,
                instanceId: guid.Replace('-','_')); // Valid only with alphanum and underscores
            _logger.LogInformation($"SubscriberAPI/Order-Finished [guid:{guid}]");

        }
    }
}
