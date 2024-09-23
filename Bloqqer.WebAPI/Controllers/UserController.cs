using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Controllers;
using Bloqqer.WebAPI.Models;
using Bloqqer.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bloqqer.Controllers;

[Route("api/v1/[controller]")]
[SwaggerTag("User related endpoints")]
public sealed class UserController(
    IUserService userService,
    ILogger<UserController> logger
) : APIController(logger)
{
    private readonly IUserService _userService = userService;

    [AllowAnonymous]
    [HttpPost]
    [SwaggerOperation(
        Summary = "Register a User",
        Description = "Register's a new User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> RegisterUser(
        [FromBody, SwaggerRequestBody("User's registration information", Required = true)] RegisterUserDTO registerUserDTO
    )
    {
        return await GetResponseAsync(() => _userService.RegisterUser(registerUserDTO));
    }

    [AllowAnonymous]
    [HttpPost]
    [Route("login")]
    [SwaggerOperation(
        Summary = "Login a User",
        Description = "Authenticates and logs in a User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> LoginUser(
        [FromBody, SwaggerRequestBody("User's login credentials", Required = true)] LoginUserDTO loginUserDTO
    )
    {
        return await GetResponseAsync(() => _userService.LoginUser(loginUserDTO));
    }

    [HttpPost]
    [Route("logout")]
    [SwaggerOperation(
        Summary = "Logout a User",
        Description = "Logs out the currently logged in User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> LogoutUser()
    {
        return await GetResponseAsync(_userService.LogoutUser);
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("email")]
    [SwaggerOperation(
        Summary = "Confirm a User email",
        Description = "Confirms a User's email address"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<bool>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<bool>))]
    public async Task<IActionResult> ConfirmUserEmail(
        [FromQuery, SwaggerParameter("User's email address")] string email,
        [FromQuery, SwaggerParameter("User's confirmation email token")] string confirmEmailToken
    )
    {
        return await GetResponseAsync(() => _userService.ConfirmUserEmail(email, confirmEmailToken));
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("reset")]
    [SwaggerOperation(
        Summary = "Request a User password reset",
        Description = "Requests a User password reset"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> RequestUserPasswordReset(
        [FromQuery, SwaggerParameter("User's email address")] string email
    )
    {
        return await GetResponseAsync(() => _userService.RequestUserPasswordReset(email));
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("password")]
    [SwaggerOperation(
        Summary = "Confirm a User password reset",
        Description = "Confirms a User password reset"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<bool>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<bool>))]
    public async Task<IActionResult> ConfirmUserPasswordReset(
        [FromQuery, SwaggerParameter("User's email address")] string email,
        [FromQuery, SwaggerParameter("User's new password")] string newPassword,
        [FromQuery, SwaggerParameter("User's new password confirmation")] string newPasswordConfirmation,
        [FromQuery, SwaggerParameter("User's password reset token")] string resetPasswordToken
    )
    {
        return await GetResponseAsync(() => _userService.ConfirmUserPasswordReset(
            email,
            newPassword,
            newPasswordConfirmation,
            resetPasswordToken
        ));
    }
}