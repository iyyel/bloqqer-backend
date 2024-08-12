using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface ICommentService
{
    Task<Guid> CreateComment(CreateCommentDTO commentDTO);

    Task<ViewCommentDTO> GetCommentByCommentId(Guid commentId);

    // Get a comment by comment id

    // Get all comments by post id

    // Get all comments by user id (all comments that this user has written)

    // Update a comment

    // Remove a comment
}