using Bloqqer.Domain.Models;

namespace Bloqqer.Infrastructure.ViewModels;

public sealed record ViewPostDTO(
    Guid Id,
    Guid BloqId,
    Guid AuthorId,
    string Title,
    string Description,
    string? Content,
    bool IsPublished,
    DateTime? Published,
    // TODO: This should not be Comment here, but ViewCommentDTO. Need AutoMapper configuration. :)
    ICollection<Comment>? Comments,
    // TODO: This should not be Reaction here, but ViewReactionDTO. Need AutoMapper configuration. :)
    ICollection<Reaction>? Reactions
);