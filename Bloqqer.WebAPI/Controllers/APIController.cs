using Bloqqer.Application.Exceptions;
using Bloqqer.WebAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers;

[ApiController]
[Authorize]
[Produces("application/json")]
public abstract class APIController(
  ILogger<APIController> _logger
) : ControllerBase
{
    private readonly ILogger<APIController> _logger = _logger;

    protected void LogInfo(string message, object method)
    {
        _logger.LogInformation("LogInfo: {Method} : {Message}", method, message);
    }

    protected void LogError(string message)
    {
        _logger.LogError("LogError: {Message}", message);
    }

    protected async Task<IActionResult> GetResponseAsync<T>(Func<Task<T>> getServiceDataFunc)
    {
        try
        {
            var result = await getServiceDataFunc();

            var response = new ResponseMessage<T>()
            {
                Success = true,
                Data = result,
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            return LogExceptionAndCreateResponse<T>(ex);
        }
    }

    protected IActionResult GetResponse<T>(Func<T> getServiceDataFunc)
    {
        try
        {
            var result = getServiceDataFunc();

            var response = new ResponseMessage<T>()
            {
                Success = true,
                Data = result,
            };

            return Ok(response);
        }
        catch (Exception ex)
        {
            return LogExceptionAndCreateResponse<T>(ex);
        }
    }

    // TODO: Redo logic
    private IActionResult LogExceptionAndCreateResponse<T>(Exception ex)
    {
        LogError(ex.Message);

        var response = new ResponseMessage<T>()
        {
            Success = false,
            Error = ex.Message,
        };

        if (ex is BadRequestException)
        {
            return BadRequest(response);
        }
        else if (ex is NotFoundException)
        {
            return NotFound(response);
        }
        else if (ex is UnauthorizedException)
        {
            return Unauthorized(response);
        }
        else
        {
            return StatusCode(500, response);
        }
    }
}