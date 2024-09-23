using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Controllers;
using Bloqqer.WebAPI.Models;
using Bloqqer.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bloqqer.Controllers;

[Route("api/v1/[controller]")]
[SwaggerTag("Post related endpoints")]
public sealed class PostController(
    IPostService postService,
    ILogger<PostController> logger
) : APIController(logger)
{
    private readonly IPostService _postService = postService;

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a Post",
        Description = "Creates a new Post for the logged in User"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> CreatePost(
        [FromBody, SwaggerRequestBody("Post creation information", Required = true)] CreatePostDTO createPost
    )
    {
        return await GetResponseAsync(() => _postService.CreatePost(createPost));
    }

    [HttpGet]
    [SwaggerOperation(
        Summary = "Get a Post",
        Description = "Gets a Post by Post Id"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ViewPostDTO>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ViewPostDTO>))]
    public async Task<IActionResult> GetPostbyPostId(
        [FromQuery, SwaggerParameter("Post GUID")] Guid postId
    )
    {
        return await GetResponseAsync(() => _postService.GetPostByPostId(postId));
    }

    [HttpGet]
    [Route("bloq")]
    [SwaggerOperation(
        Summary = "Get Posts from Bloq",
        Description = "Gets Posts associated with the Bloq Id"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ICollection<ViewPostDTO>>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ICollection<ViewPostDTO>>))]
    public async Task<IActionResult> GetPostsByBloqId(
        [FromQuery, SwaggerParameter("Bloq GUID")] Guid bloqId
    )
    {
        return await GetResponseAsync(() => _postService.GetPostsByBloqId(bloqId));
    }

    [HttpPut]
    [SwaggerOperation(
        Summary = "Update a Post",
        Description = "Updates the Post"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<ICollection<ViewPostDTO>>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<ICollection<ViewPostDTO>>))]
    public async Task<IActionResult> UpdatePost(
        [FromBody, SwaggerParameter("Post update information")] UpdatePostDTO updatePost
    )
    {
        return await GetResponseAsync(() => _postService.UpdatePost(updatePost));
    }

    [HttpDelete]
    [SwaggerOperation(
        Summary = "Remove a Post",
        Description = "Removes the Post"
    )]
    [SwaggerResponse(200, "OK", typeof(ResponseMessage<Guid>))]
    [SwaggerResponse(401, "Unauthorized", typeof(ResponseMessage<Guid>))]
    public async Task<IActionResult> RemovePost(
        [FromQuery, SwaggerParameter("Post GUID")] Guid postId
    )
    {
        return await GetResponseAsync(() => _postService.RemovePost(postId));
    }
}