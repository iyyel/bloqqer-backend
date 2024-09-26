namespace Bloqqer.Infrastructure.ViewModels;

public sealed record CreatePostDTO(
    Guid BloqId,
    string Title,
    string Description,
    string Content,
    bool IsPublished
);