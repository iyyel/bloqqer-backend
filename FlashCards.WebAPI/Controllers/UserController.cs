using FlashCards.DataAccess.Services.Interfaces;
using FlashCards.Infrastructure.ViewModels;
using FlashCards.WebAPI.Errors;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlashCards.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class UserController(IUserService userService, ILogger<UserController> logger) : ControllerBase
{
    private readonly IUserService _userService = userService;

    private readonly ILogger<UserController> _logger = logger;

    [Route("users")]
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<UserDTO>), 200)]
    [ProducesResponseType(typeof(string), 404)]
    public async Task<ActionResult<(APIError? Error, ICollection<UserDTO>? Users)>> GetUsers()
    {
        return Ok(await _userService.GetAllUsers());
    }
}