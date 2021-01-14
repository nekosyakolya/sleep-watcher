using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SleepWatcher.Core.Services;
using SleepWatcher.Core.Entities.DTO;
using System.Linq;

namespace SleepWatcher.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        private readonly ILogger<UserController> _logger;

        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet]
        public IEnumerable<User> Get(int id)
        {
            yield return _userService.GetUser(id);
        }

        [HttpPost]
        public IActionResult SaveUser([FromBody] User data)
        {
            var properties = data.GetType().GetProperties();
            if (properties.Any(propertyInfo => propertyInfo.GetValue(data) == null))
            {
                return BadRequest();
            }

            _userService.AddUser(data);
            return Ok();
        }
    }
}
