namespace Bloqqer.Infrastructure.Models;

public class Bloq : BaseEntity<Guid>
{
    public const int MaxTitleLength = 256;

    public const int MaxDescriptionLength = 256;

    public required Guid AuthorId { get; set; }

    public virtual ApplicationUser? Author { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsPrivate { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public required virtual ICollection<Post> Posts { get; set; }

    public required virtual ICollection<Reaction> Reactions { get; set; }

    public static Bloq Create(
        Guid authorId,
        string title,
        string description,
        Guid createdBy,
        bool isPrivate = false,
        Guid? id = null,
        bool isPublished = false,
        DateTime? published = null)
    {
        return new Bloq()
        {
            Id = id ?? Guid.NewGuid(),
            AuthorId = authorId,
            Title = title,
            Description = description,
            CreatedBy = createdBy,
            IsPrivate = isPrivate,
            IsPublished = isPublished,
            Published = published ?? (isPublished ? DateTime.UtcNow : null),
            CreatedOn = DateTime.UtcNow,
            Posts = [],
            Reactions = [],
        };
    }
}