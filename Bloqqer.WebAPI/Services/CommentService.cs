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

        var newComment = new Comment
        {
            Id = Guid.NewGuid(),
            PostId = commentDTO.PostId,
            AuthorId = userId,
            Content = commentDTO.Content,
            CreatedBy = userId,
            CreatedOn = DateTime.UtcNow
        };

        await _unitOfWork.Comments.AddAsync(newComment);
        await _unitOfWork.SaveChangesAsync();

        return newComment.Id;
    }

    public async Task<ViewCommentDTO> GetCommentByCommentId(Guid commentId)
    {
        var comment = await _unitOfWork.Comments.GetByIdAsync(commentId)
            ?? throw new NotFoundException($"Comment with Id ({commentId}) was not found");

        return new ViewCommentDTO(
            PostId: comment.PostId,
            AuthorId: comment.AuthorId,
            Content: comment.Content,
            Reactions: comment.Reactions
        );
    }
}