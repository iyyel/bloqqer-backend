namespace Bloqqer.Infrastructure.ViewModels;

public sealed record CreateBloqDTO(
    string Title,
    string Description,
    bool IsPrivate
);