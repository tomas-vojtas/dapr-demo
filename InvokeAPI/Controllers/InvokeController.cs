using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Dapr.Client;

namespace InvokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InvokeController : ControllerBase
    {
        private readonly ILogger<InvokeController> _logger;

        public InvokeController(ILogger<InvokeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Test")]
        public async Task<string> GetInvoke()
        {
            _logger.LogInformation($"InvokeAPI/Invoke/Test-Started");
            var httpClient = DaprClient.CreateInvokeHttpClient();
            var response =  await httpClient.GetAsync($"http://publisherapi/test");
            _logger.LogInformation($"InvokeAPI/Invoke/Test-Finished");
            return await response.Content.ReadAsStringAsync();
        }
        [HttpGet("PublishOrder")]
        public async Task<string> GetInvokePublish()
        {
            _logger.LogInformation($"InvokeAPI/Invoke/PublishOrder-Started");
            var httpClient = DaprClient.CreateInvokeHttpClient();
            var response = await httpClient.GetAsync($"http://publisherapi/publishorder");
            _logger.LogInformation($"InvokeAPI/Invoke/PublishOrder-Finished");
            return await response.Content.ReadAsStringAsync();
        }
        [HttpGet("PublishTest")]
        public async Task<string> GetInvokePublishTest()
        {
            _logger.LogInformation($"InvokeAPI/Invoke/PublishTest-Started");
            var httpClient = DaprClient.CreateInvokeHttpClient();
            var response = await httpClient.GetAsync($"http://publisherapi/publishtest");
            _logger.LogInformation($"InvokeAPI/Invoke/PublishTest-Finished");
            return await response.Content.ReadAsStringAsync();
        }
    }
}