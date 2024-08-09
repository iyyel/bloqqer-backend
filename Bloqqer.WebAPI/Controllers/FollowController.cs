using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Models;
using Bloqqer.WebAPI.Services.Interfaces;
using CleanArchitecture.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bloqqer.WebAPI.Controllers;

[ApiController]
// [Authorize]
[Route("api/v1/[controller]")]
[Produces("application/json")]
public sealed class FollowController(
    IFollowService followService,
    ILogger<FollowController> logger
) : APIController(logger)
{
    private readonly IFollowService _followService = followService;

    [HttpPost]
    [Route("{followedId}")]
    [SwaggerOperation("Follow a user")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> FollowUser([FromRoute] Guid followedId)
    {
        return await GetResponseAsync(() => _followService.FollowUser(followedId));
    }

    [HttpDelete]
    [Route("{followedId}")]
    [SwaggerOperation("Unfollow a user")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> UnfollowUser([FromRoute] Guid followedId)
    {
        return await GetResponseAsync(() => _followService.UnfollowUser(followedId));
    }

    [HttpGet]
    [Route("followers/{userId}")]
    [SwaggerOperation("Get followers")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ViewFollowsDTO>))]
    public async Task<IActionResult> GetFollowers([FromRoute] Guid userId)
    {
        return await GetResponseAsync(() => _followService.GetFollowers(userId));
    }

    [HttpGet]
    [Route("following/{userId}")]
    [SwaggerOperation("Get following")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ViewFollowsDTO>))]
    public async Task<IActionResult> GetFollowing([FromRoute] Guid userId)
    {
        return await GetResponseAsync(() => _followService.GetFollowing(userId));
    }
}