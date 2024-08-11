using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Models;
using Bloqqer.WebAPI.Services.Interfaces;
using CleanArchitecture.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bloqqer.WebAPI.Controllers;

[Route("api/v1/[controller]")]
[SwaggerTag("Follow related endpoints")]
public sealed class FollowController(
    IFollowService followService,
    ILogger<FollowController> logger
) : APIController(logger)
{
    private readonly IFollowService _followService = followService;

    [HttpPost]
    [SwaggerOperation(
        Summary = "Follow a User",
        Description = "Follows a new User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> FollowUser(
        [FromQuery, SwaggerParameter("User GUID")] Guid userId
    )
    {
        return await GetResponseAsync(() => _followService.FollowUser(userId));
    }

    [HttpDelete]
    [SwaggerOperation(
        Summary = "Unfollow a User",
        Description = "Unfollows a User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> UnfollowUser(
        [FromQuery, SwaggerParameter("User GUID")] Guid userId
    )
    {
        return await GetResponseAsync(() => _followService.UnfollowUser(userId));
    }

    [HttpGet]
    [Route("followers")]
    [SwaggerOperation(
        Summary = "Get followers",
        Description = "Get followers of the User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ViewFollowsDTO>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ViewFollowsDTO>))]
    public async Task<IActionResult> GetFollowers(
        [FromQuery, SwaggerParameter("User GUID")] Guid userId
    )
    {
        return await GetResponseAsync(() => _followService.GetFollowers(userId));
    }

    [HttpGet]
    [Route("following")]
    [SwaggerOperation(
        Summary = "Get following",
        Description = "Get following of the User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ViewFollowsDTO>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ViewFollowsDTO>))]
    public async Task<IActionResult> GetFollowing(
        [FromQuery, SwaggerParameter("User GUID")] Guid userId
    )
    {
        return await GetResponseAsync(() => _followService.GetFollowing(userId));
    }
}