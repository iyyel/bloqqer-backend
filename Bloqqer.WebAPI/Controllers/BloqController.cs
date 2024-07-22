using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Errors;
using Bloqqer.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bloqqer.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class BloqController(IBloqService bloqService, ILogger<BloqController> logger) : ControllerBase
{
    private readonly IBloqService _bloqService = bloqService;

    private readonly ILogger<BloqController> _logger = logger;

    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, Guid? BloqId)>> Create(CreateBloqDTO createBloq)
    {
        return Ok(await _bloqService.Create(createBloq));
    }

    [Authorize]
    [HttpGet]
    [Route("user/{id}")]
    [ProducesResponseType(typeof(ICollection<ViewBloqDTO>), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, ICollection<ViewBloqDTO>? ViewBloqDTOs)>> GetByUserId(Guid id)
    {
        return Ok(await _bloqService.GetByUserId(id));
    }

    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(ICollection<ViewBloqDTO>), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, ICollection<ViewBloqDTO>? ViewBloqDTOs)>> GetAll()
    {
        return Ok(await _bloqService.GetAll());
    }

    [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, Guid? BloqId)>> Update(UpdateBloqDTO updateBloq)
    {
        return Ok(await _bloqService.Update(updateBloq));
    }
}