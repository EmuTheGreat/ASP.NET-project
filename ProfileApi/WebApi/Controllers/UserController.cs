using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService) 
        {
            _userService = userService;
        }

        [Route("get/{id}")]
        [HttpGet]
        [ProducesResponseType<User>(200)]
        public async Task<IActionResult> GetUser(uint id)
        {
            var user = await _userService.GetUserAsync(id);
            return Ok(user);
        }

        [Route("getOnline")]
        [HttpGet]
        [ProducesResponseType<User[]>(200)]
        public async Task<IActionResult> GetOnlineUsers()
        {
            var users = await _userService.GetActiveUsersAsync();
            return Ok(users);
        }

    }
}
