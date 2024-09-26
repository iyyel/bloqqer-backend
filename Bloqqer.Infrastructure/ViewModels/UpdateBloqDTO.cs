namespace Bloqqer.Infrastructure.ViewModels;

public sealed record UpdateBloqDTO(
    Guid BloqId,
    string Title,
    string Description,
    bool IsPrivate,
    bool IsPublished
);