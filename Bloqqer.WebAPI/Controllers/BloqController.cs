using Bloqqer.DataAccess.Services.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Errors;
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
    public ActionResult<(APIError? Error, Guid? BloqId)> CreateBloq(CreateBloqDTO createBloq)
    {
        return Ok(_bloqService.CreateBloq(createBloq));
    }

}