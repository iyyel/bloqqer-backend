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
public sealed class BloqController(
    IBloqService bloqService,
    ILogger<BloqController> logger
) : APIController(logger)
{
    private readonly IBloqService _bloqService = bloqService;

    [HttpPost]
    [SwaggerOperation("Create a new Bloq")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> CreateBloq([FromBody] CreateBloqDTO createBloq)
    {
        return await GetResponseAsync(() => _bloqService.CreateBloq(createBloq));
    }

    [HttpGet]
    [Route("{bloqId}")]
    [SwaggerOperation("Get a Bloq by Bloq id")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ViewBloqDTO>))]
    public async Task<IActionResult> GetBloqByBloqIdId([FromRoute] Guid bloqId)
    {
        return await GetResponseAsync(() => _bloqService.GetBloqByBloqId(bloqId));
    }

    [HttpGet]
    [Route("user/{userId}")]
    [SwaggerOperation("Get Bloqs by User id")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ICollection<ViewBloqDTO>>))]
    public async Task<IActionResult> GetBloqsByUserId([FromRoute] Guid userId)
    {
        return await GetResponseAsync(() => _bloqService.GetBloqsByUserId(userId));
    }

    [HttpGet]
    [SwaggerOperation("Get all Bloqs")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ICollection<ViewBloqDTO>>))]
    public async Task<IActionResult> GetAllBloqs()
    {
        return await GetResponseAsync(() => _bloqService.GetAllBloqs());
    }

    [HttpGet]
    [Route("followed")]
    [SwaggerOperation("Get all Bloqs that the user follows")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ICollection<ViewBloqDTO>>))]
    public async Task<IActionResult> GetFollowedUsersBloqs()
    {
        return await GetResponseAsync(() => _bloqService.GetFollowedUsersBloqs());
    }

    [HttpPut]
    [SwaggerOperation("Updates the Bloq")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> UpdateBloq([FromBody] UpdateBloqDTO updateBloq)
    {
        return await GetResponseAsync(() => _bloqService.UpdateBloq(updateBloq));
    }

    [HttpDelete]
    [Route("{bloqId}")]
    [SwaggerOperation("Removes the Bloq")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> RemoveBloq([FromRoute] Guid bloqId)
    {
        return await GetResponseAsync(() => _bloqService.RemoveBloq(bloqId));
    }
}