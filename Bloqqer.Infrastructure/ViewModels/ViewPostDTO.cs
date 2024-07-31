using Bloqqer.Domain.Models;

namespace Bloqqer.Infrastructure.ViewModels;

public class ViewPostDTO
{
    public required Guid BloqId { get; set; }

    public required Guid AuthorId { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public string? Content { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    // TODO: This should not be Comment here, but ViewCommentDTO. Need AutoMapper configuration. :)
    public ICollection<Comment>? Comments { get; set; }

    // TODO: This should not be Reaction here, but ViewReactionDTO. Need AutoMapper configuration. :)
    public ICollection<Reaction>? Reactions { get; set; }
}