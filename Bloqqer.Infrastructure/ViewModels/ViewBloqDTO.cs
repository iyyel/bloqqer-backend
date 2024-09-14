using Bloqqer.Domain.Models;

namespace Bloqqer.Infrastructure.ViewModels;

public class ViewBloqDTO
{
    public required Guid Id { get; set; }

    public required Guid AuthorId { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsPrivate { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    // TODO: This should not be Post here, but ViewPostDTO. Need AutoMapper configuration. :)
    public ICollection<Post>? Posts { get; set; }

    // TODO: This should not be Reaction here, but ViewReactionDTO. Need AutoMapper configuration. :)
    public ICollection<Reaction>? Reactions { get; set; }
}