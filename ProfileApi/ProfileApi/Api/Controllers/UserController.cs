using Microsoft.AspNetCore.Mvc;
using ProfileApi.Api.Controllers.User.Response;
using ProfileApi.Api.Controllers.User.Requests;
using ProfileApi.Logic.User;

namespace ProfileApi.Api.Controllers;


[Route("route")]
public class UserController : ControllerBase
{
    private readonly IUserManager _userManager;

    public UserController(IUserManager userLogicManager)
    {
        _userManager = userLogicManager;
    }

    [ProducesResponseType<UserInfoResponse>(200)]
    public async Task<IActionResult> GetInfoAsync([FromQuery] Guid userId)
    {
        var userName = await _userManager.GetUserNameAsync(userId);
        return Ok(new UserInfoResponse
        {
            Id = default,
            Name = null,
            Login = null,
            Phone = null,
            Email = null,
            Country = null
        });
    }

    [HttpPost]
    [ProducesResponseType(typeof(UserResponseCreate), 200)]
    public async Task<ActionResult> CreateUserAsync(UserRequestCreate dto)
    {
        var res = await _userManager.CreateUserAsync(new UserLogic
        {
            Name = dto.Name,
            Login = dto.Login,
            Phone = dto.Phone,
            Email = dto.Email,
            Country = dto.Country
        }); ;

        return Ok(new UserResponseCreate
        {
            Id = res
        });
    }
}

