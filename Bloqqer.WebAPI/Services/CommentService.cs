using Bloqqer.Application.Exceptions;
using Bloqqer.Domain.Models;
using Bloqqer.Infrastructure.UnitOfWork.Interfaces;
using Bloqqer.Infrastructure.ViewModels;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

public sealed class CommentService(
    IUnitOfWork _unitOfWork,
    IUserService _userService
) : ICommentService
{
    private readonly IUnitOfWork _unitOfWork = _unitOfWork;
    private readonly IUserService _userService = _userService;

    public async Task<Guid> CreateComment(CreateCommentDTO commentDTO)
    {
        var userId = _userService.GetLoggedInUserId();

        var newComment = Comment.Create(
            commentDTO.PostId,
            userId,
            commentDTO.Content,
            userId,
            Guid.NewGuid(),
            commentDTO.IsPublished
        );

        await _unitOfWork.Comments.AddAsync(newComment);
        await _unitOfWork.SaveChangesAsync();

        return newComment.Id;
    }

    public async Task<ViewCommentDTO> GetCommentByCommentId(Guid commentId)
    {
        var comment = await _unitOfWork.Comments.GetByIdAsync(commentId)
            ?? throw new NotFoundException($"Comment with Id ({commentId}) was not found");

        return new ViewCommentDTO()
        {
            // TODO: Why is this exception necessary again?
            PostId = comment.PostId ?? throw new NotFoundException($"Comment with Id ({commentId}) has no associated Post"),
            AuthorId = comment.AuthorId,
            Content = comment.Content,
            IsPublished = comment.IsPublished,
            Published = comment.Published,
            Reactions = comment.Reactions,
        };
    }
}