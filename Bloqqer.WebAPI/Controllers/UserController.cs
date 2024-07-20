using Bloqqer.DataAccess.Services.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloqqer.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
{
    private readonly IUserService _userService = userService;

    private readonly ILogger<UserController> _logger = logger;

    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(string), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public ActionResult<(APIError? Error, ICollection<UserDTO>? Users)> GetLoggedInUser()
    {
        return Ok(_userService.GetLoggedInUserId());
    }

    [Route("all")]
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<UserDTO>), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, ICollection<UserDTO>? Users)>> GetUsers()
    {
        return Ok(await _userService.GetAllUsers());
    }
}