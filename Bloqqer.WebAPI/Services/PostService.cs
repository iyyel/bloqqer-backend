using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class PostService(
    IUnitOfWork _unitOfWork,
    IUserService userService
) : IPostService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
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

    public async Task<ViewPostDTO> GetPostByPostId(Guid postId)
    {
        // TODO: Find a better exception handling pattern.
        var post = await _unitOfWork.Posts.GetByIdAsync(postId) ?? throw new ArgumentException("Post not found?");

        return new ViewPostDTO()
        {
            BloqId = post.Id,
            AuthorId = post.AuthorId,
            Title = post.Title,
            Description = post.Description,
            IsPublished = post.IsPublished,
            Published = post.Published,
            Comments = post.Comments,
            Reactions = post.Reactions,
        };
    }

    public async Task<ICollection<ViewPostDTO>> GetPostsByBloqId(Guid bloqId)
    {
        return (await _unitOfWork.Bloqs.FindAsync(b => b.Id == bloqId))
            .SelectMany(b => b.Posts)
            .Select(post =>
            new ViewPostDTO()
            {
                BloqId = post.Id,
                AuthorId = post.AuthorId,
                Title = post.Title,
                Description = post.Description,
                IsPublished = post.IsPublished,
                Published = post.Published,
                Comments = post.Comments,
                Reactions = post.Reactions,
            }).ToList();
    }

    public async Task<Guid> UpdatePost(UpdatePostDTO updatePost)
    {
        // TODO: Find a better exception handling pattern.
        var userId = _userService.GetLoggedInUserId() ?? throw new ArgumentException("Not logged in?");
        var currentPost = await _unitOfWork.Posts.GetByIdAsync(updatePost.PostId) ?? throw new ArgumentException("Bloq not found?");

        if (userId != currentPost.AuthorId)
        {
            throw new Exception("You can't update somebody else's post!");
        }

        currentPost.Title = updatePost.Title;
        currentPost.Description = updatePost.Description;
        currentPost.Content = updatePost.Content;
        currentPost.IsPublished = updatePost.IsPublished;
        currentPost.Published = !currentPost.IsPublished && updatePost.IsPublished ? DateTime.UtcNow : currentPost.Published;
        currentPost.ModifiedBy = userId;
        currentPost.ModifiedOn = DateTime.UtcNow;

        _unitOfWork.Posts.Update(currentPost);
        await _unitOfWork.SaveChangesAsync();

        return currentPost.Id;
    }

    public async Task<Guid> RemovePost(Guid postId)
    {
        // TODO: Find a better exception handling pattern.
        var post = await _unitOfWork.Posts.GetByIdAsync(postId) ?? throw new ArgumentException("Post not found?");

        _unitOfWork.Posts.Remove(post);
        await _unitOfWork.SaveChangesAsync();

        return post.Id;
    }
}