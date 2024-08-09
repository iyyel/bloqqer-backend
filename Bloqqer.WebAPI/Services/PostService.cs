using Bloqqer.Application.Exceptions;
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
        var userId = _userService.GetLoggedInUserId();

        var newPost = Post.Create(
            createPost.BloqId,
            userId,
            createPost.Title,
            createPost.Description,
            createPost.Content,
            userId,
            createPost.IsPublished
        );

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
        var bloq = await _unitOfWork.Bloqs.GetByIdAsync(bloqId)
            ?? throw new NotFoundException($"Bloq with Id ({bloqId}) was not found");

        return bloq.Posts.Select(post =>
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