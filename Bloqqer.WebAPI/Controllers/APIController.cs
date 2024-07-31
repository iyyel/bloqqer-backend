using Bloqqer.WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

public abstract class APIController : ControllerBase
{
    // TODO: Redo this method :)
    protected new IActionResult Response(object? resultData = null)
    {
        return Ok(
            new ResponseMessage<object>
            {
                Success = true,
                Data = resultData
            });
    }
}