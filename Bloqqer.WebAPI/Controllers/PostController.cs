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
public sealed class PostController(
    IPostService postService,
    ILogger<PostController> logger
) : APIController
{
    private readonly IPostService _postService = postService;
    private readonly ILogger<PostController> _logger = logger;

    [HttpPost]
    [SwaggerOperation("Create a new Post")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDTO createPost)
    {
        return Response(await _postService.CreatePost(createPost));
    }

    [HttpGet]
    [Route("{postId}")]
    [SwaggerOperation("Get Post by Post id")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ViewPostDTO>))]
    public async Task<IActionResult> GetPostbyPostId([FromRoute] Guid postId)
    {
        return Response(await _postService.GetPostByPostId(postId));
    }

    [HttpGet]
    [Route("bloq/{bloqId}")]
    [SwaggerOperation("Get Posts by Bloq id")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ICollection<ViewPostDTO>>))]
    public async Task<IActionResult> GetPostsByBloqId([FromRoute] Guid bloqId)
    {
        return Response(await _postService.GetPostsByBloqId(bloqId));
    }

    [HttpPut]
    [SwaggerOperation("Updates the Post")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDTO updatePost)
    {
        return Response(await _postService.UpdatePost(updatePost));
    }

    [HttpDelete]
    [Route("{postId}")]
    [SwaggerOperation("Removes the Post")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> RemovePost([FromRoute] Guid postId)
    {
        return Response(await _postService.RemovePost(postId));
    }
}