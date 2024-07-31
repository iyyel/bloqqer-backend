using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Errors;
using Bloqqer.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bloqqer.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BloqController(
    IBloqService bloqService,
    ILogger<BloqController> logger
) : ControllerBase
{
    private readonly IBloqService _bloqService = bloqService;

    private readonly ILogger<BloqController> _logger = logger;

    // [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, Guid? BloqId)>> CreateBloq(CreateBloqDTO createBloq)
    {
        return Ok(await _bloqService.CreateBloq(createBloq));
    }

    // [Authorize]
    [HttpGet]
    [Route("{bloqId}")]
    [ProducesResponseType(typeof(ViewBloqDTO), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, ViewBloqDTO? ViewBloqDTO)>> GetBloqByBloqIdId(Guid bloqId)
    {
        return Ok(await _bloqService.GetBloqByBloqId(bloqId));
    }

    // [Authorize]
    [HttpGet]
    [Route("user/{userId}")]
    [ProducesResponseType(typeof(ICollection<ViewBloqDTO>), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, ICollection<ViewBloqDTO>? ViewBloqDTOs)>> GetBloqsByUserId(Guid userId)
    {
        return Ok(await _bloqService.GetBloqsByUserId(userId));
    }

    // [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<ViewBloqDTO>), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, ICollection<ViewBloqDTO>? ViewBloqDTOs)>> GetAllBloqs()
    {
        return Ok(await _bloqService.GetAllBloqs());
    }

    // [Authorize]
    [HttpGet]
    [Route("followed")]
    [ProducesResponseType(typeof(ICollection<ViewBloqDTO>), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, ICollection<ViewBloqDTO>? ViewBloqDTOs)>> GetFollowedUsersBloqs()
    {
        return Ok(await _bloqService.GetFollowedUsersBloqs());
    }

    // [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, Guid? BloqId)>> UpdateBloq(UpdateBloqDTO updateBloq)
    {
        return Ok(await _bloqService.UpdateBloq(updateBloq));
    }

    // [Authorize]
    [HttpDelete]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, Guid? BloqId)>> RemoveBloq(Guid bloqId)
    {
        return Ok(await _bloqService.RemoveBloq(bloqId));
    }
}