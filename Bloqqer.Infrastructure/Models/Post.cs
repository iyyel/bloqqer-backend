namespace Bloqqer.Infrastructure.Models;

public class Post : BaseEntity<Guid>
{
    public const int MaxTitleLength = 256;

    public const int MaxDescriptionLength = 256;

    public const int MaxContentLength = 256;

    public Guid? BloqId { get; set; }

    public Bloq? Bloq { get; set; }

    public required Guid AuthorId { get; set; }

    public virtual ApplicationUser? Author { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public required virtual ICollection<Comment> Comments { get; set; }

    public static Post Create(
        Guid bloqId,
        Guid authorId,
        string title,
        string description,
        string content,
        Guid createdBy,
        bool isPublished = false,
        Guid? id = null,
        DateTime? published = null)
    {
        return new Post()
        {
            Id = id ?? Guid.NewGuid(),
            BloqId = bloqId,
            AuthorId = authorId,
            Title = title,
            Description = description,
            Content = content,
            CreatedBy = createdBy,
            IsPublished = isPublished,
            Published = published ?? (isPublished ? DateTime.UtcNow : null),
            CreatedOn = DateTime.UtcNow,
            Comments = [],
        };
    }
}