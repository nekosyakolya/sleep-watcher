using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SleepWatcher.Core.Entities.Common;
using SleepWatcher.Core.Entities.DTO;

namespace SleepWatcher.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestUsersToSleepController : ControllerBase
    {
        private readonly ILogger<TestUsersToSleepController> _logger;

        private readonly IUsersToSleepService _userService;

        public TestUsersToSleepController(ILogger<TestUsersToSleepController> logger, IUsersToSleepService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userService.Get();
        }
    }
}