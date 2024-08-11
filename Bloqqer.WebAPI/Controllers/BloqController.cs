using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Models;
using Bloqqer.WebAPI.Services.Interfaces;
using CleanArchitecture.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bloqqer.Controllers;

[Route("api/v1/[controller]")]
[SwaggerTag("Bloq related endpoints")]
public sealed class BloqController(
    IBloqService bloqService,
    ILogger<BloqController> logger
) : APIController(logger)
{
    private readonly IBloqService _bloqService = bloqService;

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Bloq",
        Description = "Creates a new Bloq for the logged in User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> CreateBloq(
        [FromBody, SwaggerParameter("Bloq creation information")] CreateBloqDTO createBloq
    )
    {
        return await GetResponseAsync(() => _bloqService.CreateBloq(createBloq));
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get a Bloq",
        Description = "Gets a Bloq by Bloq Id"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ViewBloqDTO>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ViewBloqDTO>))]
    public async Task<IActionResult> GetBloqByBloqIdId(
        [FromQuery, SwaggerParameter("Bloq GUID")] Guid bloqId
    )
    {
        return await GetResponseAsync(() => _bloqService.GetBloqByBloqId(bloqId));
    }

    [HttpGet]
    [Route("user")]
    [SwaggerOperation(
        Summary = "Get Bloqs from User",
        Description = "Gets Bloqs associated with the User Id"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ICollection<ViewBloqDTO>>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ICollection<ViewBloqDTO>>))]
    public async Task<IActionResult> GetBloqsByUserId(
        [FromQuery, SwaggerParameter("User GUID")] Guid userId
    )
    {
        return await GetResponseAsync(() => _bloqService.GetBloqsByUserId(userId));
    }

    [HttpGet]
    [Route("all")]
    [SwaggerOperation(
        Summary = "Get all Bloqs",
        Description = "Gets all existing Bloqs"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ICollection<ViewBloqDTO>>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ICollection<ViewBloqDTO>>))]
    public async Task<IActionResult> GetAllBloqs()
    {
        return await GetResponseAsync(_bloqService.GetAllBloqs);
    }

    [HttpGet]
    [Route("following")]
    [SwaggerOperation(
        Summary = "Get all following Bloqs",
        Description = "Gets all Bloqs that the logged in User is following"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ICollection<ViewBloqDTO>>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ICollection<ViewBloqDTO>>))]
    public async Task<IActionResult> GetFollowingUsersBloqs()
    {
        return await GetResponseAsync(_bloqService.GetFollowingUsersBloqs);
    }

    [HttpPut]
    [SwaggerOperation(
        Summary = "Update a Bloq",
        Description = "Updates the Bloq"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ICollection<Guid>>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ICollection<Guid>>))]
    public async Task<IActionResult> UpdateBloq(
        [FromBody, SwaggerParameter("Bloq update information")] UpdateBloqDTO updateBloq
    )
    {
        return await GetResponseAsync(() => _bloqService.UpdateBloq(updateBloq));
    }

    [HttpDelete]
    [SwaggerOperation(
        Summary = "Remove a Bloq",
        Description = "Removes the Bloq"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ICollection<Guid>>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ICollection<Guid>>))]
    public async Task<IActionResult> RemoveBloq(
        [FromQuery, SwaggerParameter("Bloq GUID")] Guid bloqId
    )
    {
        return await GetResponseAsync(() => _bloqService.RemoveBloq(bloqId));
    }
}