using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Models;
using Bloqqer.WebAPI.Services.Interfaces;
using CleanArchitecture.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bloqqer.Controllers;

[ApiController]
// [Authorize]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public sealed class UserController(
    IUserService userService,
    ILogger<UserController> logger
) : APIController
{
    private readonly IUserService _userService = userService;
    private readonly ILogger<UserController> _logger = logger;

    [HttpGet]
    [SwaggerOperation("Get logged in user id")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public IActionResult GetLoggedInUser()
    {
        return Response(_userService.GetLoggedInUserId());
    }

    [HttpGet]
    [Route("all")]
    [SwaggerOperation("Get all users")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ICollection<UserDTO>>))]
    public async Task<IActionResult> GetUsers()
    {
        return Response(await _userService.GetAllUsers());
    }
}