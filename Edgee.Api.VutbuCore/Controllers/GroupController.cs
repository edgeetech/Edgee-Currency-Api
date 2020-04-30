using Edgee.Api.VutbuCore.DataLayer;
using Edgee.Api.VutbuCore.Message;
using Edgee.Api.VutbuCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Edgee.Api.VutbuCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : ControllerBase
    {
        private readonly ILogger<GroupController> _logger;
        private readonly VutbuDbContext _dbContext;
        private readonly IGroupService _groupService;

        public GroupController(ILogger<GroupController> logger,
            IGroupService groupService,
            VutbuDbContext dbContext)
        {
            _logger = logger;
            _groupService = groupService;
            _dbContext = dbContext;
        }

        [HttpPost("Create")]
        public IActionResult CreateGroup(EditGroupMessage groupMessage)
        {
            try
            {
                _groupService.CreateGroup(groupMessage);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, groupMessage);
                return BadRequest(ex.Message);
            }

            return Ok("Group created successfully");
        }

        [HttpPost("AddUserToGroup")]
        public IActionResult AddUserToGroup(EditGroupMessage groupMessage)
        {
            if (groupMessage == null)
            {
                _logger.LogError("groupMessage is null", groupMessage);
                return BadRequest("Invalid input parameters");
            }
            try
            {
                _groupService.AddUserToGroup(groupMessage.GroupId, groupMessage.UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, groupMessage);
                return BadRequest(ex.Message);
            }

            return Ok("User added to group successfully");
        }

        [HttpPost("RemoveUserFromGroup")]
        public IActionResult RemoveUserFromGroup(EditGroupMessage groupMessage)
        {
            if (groupMessage == null)
            {
                _logger.LogError("groupMessage is null", groupMessage);
                return BadRequest("Invalid input parameters");
            }
            try
            {
                _groupService.RemoveUserFromGroup(groupMessage.GroupId, groupMessage.UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, groupMessage);
                return BadRequest(ex.Message);
            }

            return Ok("User removed from group successfully");
        }

        [HttpPost("SetUserAsGroupAdmin")]
        public IActionResult SetUserAsGroupAdmin(EditGroupMessage groupMessage)
        {
            if (groupMessage == null)
            {
                _logger.LogError("groupMessage is null", groupMessage);
                return BadRequest("Invalid input parameters");
            }
            try
            {
                _groupService.SetUserAsGroupAdmin(groupMessage.GroupId, groupMessage.UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, groupMessage);
                return BadRequest(ex.Message);
            }

            return Ok("User added to admins of the group successfully");
        }

        [HttpPost("RemoveUserFromGroupAdmins")]
        public IActionResult RemoveUserFromGroupAdmins(EditGroupMessage groupMessage)
        {
            if (groupMessage == null)
            {
                _logger.LogError("groupMessage is null", groupMessage);
                return BadRequest("Invalid input parameters");
            }
            try
            {
                _groupService.RemoveUserFromGroupAdmins(groupMessage.GroupId, groupMessage.UserId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, groupMessage);
                return BadRequest(ex.Message);
            }

            return Ok("User removed from admins of the group successfully");
        }

    }
}
