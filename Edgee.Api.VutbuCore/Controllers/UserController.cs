using Edgee.Api.VutbuCore.Message;
using Edgee.Api.VutbuCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Edgee.Api.VutbuCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;
        private readonly IObfuscateService _obfuscateService;

        public UserController(ILogger<UserController> logger,
            IUserService userService,
            IObfuscateService obfuscateService
            )
        {
            _logger = logger;
            _userService = userService;
            _obfuscateService = obfuscateService;
        }

        [HttpPost]
        public IActionResult AddNewUser(EditUserMessage userMessage)
        {
            try
            {
                _userService.AddUser(userMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, userMessage);
                return BadRequest(ex.Message);
            }

            return Ok("User saved successfully");
        }

        [HttpPut]
        public IActionResult UpdateUser(EditUserMessage userMessage)
        {
            try
            {
                _userService.UpdateUser(userMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, userMessage);
                return BadRequest(ex.Message);
            }

            return Ok("User saved successfully");
        }

        [HttpDelete]
        public IActionResult DeleteUser(EditUserMessage userMessage)
        {
            try
            {
                _obfuscateService.ObfuscateUser(userMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, userMessage);
                return BadRequest(ex.Message);
            }

            return Ok("User and related information removed from system successfully");
        }
    }
}
