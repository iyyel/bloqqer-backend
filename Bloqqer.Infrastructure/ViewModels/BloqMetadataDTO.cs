namespace Bloqqer.Infrastructure.ViewModels;

public sealed record BloqMetadataDTO(
    Guid Id,
    Guid AuthorId,
    string AuthorName,
    string Title,
    string Description,
    bool IsPublished,
    DateTime? Published,
    int PostCount,
    int ReactionCount,
    int DaysSinceCreation
);