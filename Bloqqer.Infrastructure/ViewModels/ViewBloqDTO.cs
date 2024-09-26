using Bloqqer.Domain.Models;

namespace Bloqqer.Infrastructure.ViewModels;

public sealed record ViewBloqDTO(
    Guid Id,
    Guid AuthorId,
    string Title,
    string Description,
    bool IsPrivate,
    bool IsPublished,
    DateTime? Published,
    // TODO: This should not be Post here, but ViewPostDTO. Need AutoMapper configuration. :)
    ICollection<Post>? Posts,
    // TODO: This should not be Reaction here, but ViewReactionDTO. Need AutoMapper configuration. :)
    ICollection<Reaction>? Reactions
);