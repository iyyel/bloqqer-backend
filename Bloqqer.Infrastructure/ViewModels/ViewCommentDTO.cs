using Bloqqer.Domain.Models;

namespace Bloqqer.Infrastructure.ViewModels;

public sealed record ViewCommentDTO(
    Guid PostId,
    Guid AuthorId,
    string Content,
    ICollection<Reaction>? Reactions
);