using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SleepWatcher.Core.Entities.Common;

namespace SleepWatcher.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestVkSenderController : ControllerBase
    {
        private readonly ILogger<TestVkSenderController> _logger;
        private readonly ISender _sender;

        public TestVkSenderController(ILogger<TestVkSenderController> logger, ISender sender)
        {
            _logger = logger;
            _sender = sender;
        }

        [HttpGet]
        public async Task Get()
        {
            await _sender.Send("46453314,529900042", "hello");
        }
    }
}