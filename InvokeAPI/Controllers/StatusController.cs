using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text;
using Dapr.Client;

namespace InvokeAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly ILogger<InvokeController> _logger;

        public StatusController(ILogger<InvokeController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetStatus")]
        public string GetStatus()
        {
            _logger.LogInformation($"InvokeAPI/Status");
            return "Yes, I am running.";
        }
    }
}