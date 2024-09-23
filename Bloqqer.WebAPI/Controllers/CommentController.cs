using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Models;
using Bloqqer.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bloqqer.WebAPI.Controllers;

[Route("api/v1/[controller]")]
[SwaggerTag("Comment related endpoints")]
public sealed class CommentController(
    ICommentService commentService,
    ILogger<CommentController> logger
) : APIController(logger)
{
    private readonly ICommentService _commentService = commentService;

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Comment",
        Description = "Creates a new Comment by the logged in User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> CreateComment(
        [FromBody, SwaggerParameter("Comment creation information")] CreateCommentDTO createComment
    )
    {
        return await GetResponseAsync(() => _commentService.CreateComment(createComment));
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get a Comment",
        Description = "Gets a Comment by Comment Id"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ViewCommentDTO>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ViewCommentDTO>))]
    public async Task<IActionResult> GetCommentByCommentId(
        [FromQuery, SwaggerParameter("Comment GUID")] Guid commentId
    )
    {
        return await GetResponseAsync(() => _commentService.GetCommentByCommentId(commentId));
    }
}