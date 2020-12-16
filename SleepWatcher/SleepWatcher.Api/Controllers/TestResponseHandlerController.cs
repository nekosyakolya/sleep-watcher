using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SleepWatcher.Core.Entities.Common;

namespace SleepWatcher.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestResponseHandlerController : ControllerBase
    {
        private readonly ILogger<TestResponseHandlerController> _logger;
        private readonly IResponseHandler _handler;

        public TestResponseHandlerController(ILogger<TestResponseHandlerController> logger, IResponseHandler handler)
        {
            _logger = logger;
            _handler = handler;
        }

        [HttpGet]
        public IActionResult Get([FromBody] JsonElement body)
        {
            string json = JsonSerializer.Serialize(body);
            var result = _handler.GetResult(json);
  
            return Ok(result);
        }
    }
}