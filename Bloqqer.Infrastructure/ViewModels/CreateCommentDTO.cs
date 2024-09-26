namespace Bloqqer.Infrastructure.ViewModels;

public sealed record CreateCommentDTO(
    Guid PostId,
    string Content,
    bool IsPublished
);