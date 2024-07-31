using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Errors;
using Bloqqer.WebAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Bloqqer.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PostController(
    IPostService postService,
    ILogger<PostController> logger
) : ControllerBase
{
    private readonly IPostService _postService = postService;

    private readonly ILogger<PostController> _logger = logger;

    // [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, Guid? PostId)>> CreatePost(CreatePostDTO createPost)
    {
        return Ok(await _postService.CreatePost(createPost));
    }

    // [Authorize]
    [HttpGet]
    [Route("{postId}")]
    [ProducesResponseType(typeof(ViewPostDTO), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, ViewPostDTO? ViewPostDTO)>> GetPostbyPostId(Guid postId)
    {
        return Ok(await _postService.GetPostByPostId(postId));
    }

    // [Authorize]
    [HttpGet]
    [Route("bloq/{bloqId}")]
    [ProducesResponseType(typeof(ICollection<ViewPostDTO>), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, ICollection<ViewPostDTO>? ViewPostDTOs)>> GetPostsByBloqId(Guid bloqId)
    {
        return Ok(await _postService.GetPostsByBloqId(bloqId));
    }

    // [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, Guid? PostId)>> UpdatePost(UpdatePostDTO updatePost)
    {
        return Ok(await _postService.UpdatePost(updatePost));
    }

    // [Authorize]
    [HttpDelete]
    [ProducesResponseType(typeof(Guid), 200)]
    [ProducesResponseType(typeof(APIError), 404)]
    public async Task<ActionResult<(APIError? Error, Guid? PostId)>> RemoveBloq(Guid PostId)
    {
        return Ok(await _postService.RemovePost(PostId));
    }
}