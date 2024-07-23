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

}