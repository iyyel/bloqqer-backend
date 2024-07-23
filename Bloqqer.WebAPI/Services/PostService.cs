using Bloqqer.Infrastructure.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class PostService(
    IUnitOfWork unitOfWork,
    IHttpContextAccessor httpContextAccessor,
    IUserService userService
) : IPostService
{
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
    private readonly IUserService _userService = userService;

    public async Task<Guid> CreatePost(CreatePostDTO createPost)
    {
        var userGuid = _userService.GetLoggedInUserId() ?? throw new ArgumentException("Not logged in?");

        var newPost = Post.Create(
            createPost.BloqId,
            userGuid,
            createPost.Title,
            createPost.Description,
            createPost.Content,
            userGuid,
            createPost.IsPublished
        );

        await _unitOfWork.Posts.AddAsync(newPost);
        await _unitOfWork.SaveChangesAsync();

        return newPost.Id;
    }
}