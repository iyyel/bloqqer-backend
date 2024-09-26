namespace Bloqqer.Infrastructure.ViewModels;

public sealed record UpdatePostDTO(
    Guid PostId,
    string Title,
    string Description,
    string Content,
    bool IsPublished
);