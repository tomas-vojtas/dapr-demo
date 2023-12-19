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
        [HttpGet("Publish")]
        public async Task<string> GetInvokePublish()
        {
            _logger.LogInformation($"InvokeAPI/Invoke/Publish-Started");
            var httpClient = DaprClient.CreateInvokeHttpClient();
            var response = await httpClient.GetAsync($"http://publisherapi/publishorder");
            _logger.LogInformation($"InvokeAPI/Invoke/Publish-Finished");
            return await response.Content.ReadAsStringAsync();
        }
    }
}