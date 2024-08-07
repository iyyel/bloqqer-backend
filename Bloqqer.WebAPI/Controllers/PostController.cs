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
) : APIController(logger)
{
    private readonly IPostService _postService = postService;

    [HttpPost]
    [SwaggerOperation("Create a new Post")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> CreatePost([FromBody] CreatePostDTO createPost)
    {
        return await GetResponseAsync(() => _postService.CreatePost(createPost));
    }

    [HttpGet]
    [Route("{postId}")]
    [SwaggerOperation("Get Post by Post id")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ViewPostDTO>))]
    public async Task<IActionResult> GetPostbyPostId([FromRoute] Guid postId)
    {
        return await GetResponseAsync(() => _postService.GetPostByPostId(postId));
    }

    [HttpGet]
    [Route("bloq/{bloqId}")]
    [SwaggerOperation("Get Posts by Bloq id")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<ICollection<ViewPostDTO>>))]
    public async Task<IActionResult> GetPostsByBloqId([FromRoute] Guid bloqId)
    {
        return await GetResponseAsync(() => _postService.GetPostsByBloqId(bloqId));
    }

    [HttpPut]
    [SwaggerOperation("Updates the Post")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> UpdatePost([FromBody] UpdatePostDTO updatePost)
    {
        return await GetResponseAsync(() => _postService.UpdatePost(updatePost));
    }

    [HttpDelete]
    [Route("{postId}")]
    [SwaggerOperation("Removes the Post")]
    [SwaggerResponse(200, "Request successful", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> RemovePost([FromRoute] Guid postId)
    {
        return await GetResponseAsync(() => _postService.RemovePost(postId));
    }
}