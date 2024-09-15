using Bloqqer.Application.Exceptions;
using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class PostService(
    IUnitOfWork _unitOfWork,
    IUserService _userService
) : IPostService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IUserService _userService = _userService;

    public async Task<Guid> CreatePost(CreatePostDTO createPost)
    {
        var userId = _userService.GetLoggedInUserId();

        var newPost = new Post
        {
            Id = Guid.NewGuid(),
            BloqId = createPost.BloqId,
            AuthorId = userId,
            Title = createPost.Title,
            Description = createPost.Description,
            Content = createPost.Content,
            IsPublished = createPost.IsPublished,
            Published = createPost.IsPublished ? DateTime.UtcNow : null,
            CreatedBy = userId,
            CreatedOn = DateTime.UtcNow,
        };

        await _unitOfWork.Posts.AddAsync(newPost);
        await _unitOfWork.SaveChangesAsync();

        return newPost.Id;
    }

    public async Task<ViewPostDTO> GetPostByPostId(Guid postId)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(postId)
            ?? throw new NotFoundException($"Post with Id ({postId}) was not found");

        return new ViewPostDTO()
        {
            Id = post.Id,
            BloqId = post.BloqId,
            AuthorId = post.AuthorId,
            Title = post.Title,
            Description = post.Description,
            Content = post.Content,
            IsPublished = post.IsPublished,
            Published = post.Published,
            Comments = post.Comments,
            Reactions = post.Reactions,
        };
    }

    public async Task<ICollection<ViewPostDTO>> GetPostsByBloqId(Guid bloqId)
    {
        var posts = await _unitOfWork.Posts.FindAsync(p => p.BloqId == bloqId)
            ?? throw new NotFoundException($"Posts with Bloq Id ({bloqId}) was not found");

        return [.. posts
            .OrderByDescending(p => p.CreatedOn)
            .Select(post =>
            new ViewPostDTO()
            {
                Id = post.Id,
                BloqId = post.BloqId,
                AuthorId = post.AuthorId,
                Title = post.Title,
                Description = post.Description,
                Content = post.Content,
                IsPublished = post.IsPublished,
                Published = post.Published,
                Comments = [.. post?.Comments?.OrderByDescending(c => c.CreatedOn)],
                Reactions = [.. post?.Reactions?.OrderByDescending(r => r.CreatedOn)],
            })];
    }

    public async Task<Guid> UpdatePost(UpdatePostDTO updatePost)
    {
        var userId = _userService.GetLoggedInUserId();

        var currentPost = await _unitOfWork.Posts.GetByIdAsync(updatePost.PostId)
            ?? throw new NotFoundException($"Post with Id ({updatePost.PostId}) was not found");

        if (userId != currentPost.AuthorId)
        {
            throw new BadRequestException("You are not the author of this post");
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
        var post = await _unitOfWork.Posts.GetByIdAsync(postId)
            ?? throw new NotFoundException($"Post with Id ({postId}) was not found");

        _unitOfWork.Posts.Remove(post);
        await _unitOfWork.SaveChangesAsync();

        return post.Id;
    }
}