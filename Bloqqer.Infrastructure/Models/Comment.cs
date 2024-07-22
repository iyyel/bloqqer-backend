namespace Bloqqer.Infrastructure.Models;

public class Comment : BaseEntity<Guid>
{
    public const int MaxContentLength = 256;

    public Guid? PostId { get; set; }

    public virtual Post? Post { get; set; }

    public required Guid AuthorId { get; set; }

    public virtual ApplicationUser? Author { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public static Comment Create(
       Guid postId,
       Guid authorId,
       string content,
       string createdBy,
       Guid? id = null,
       bool isPublished = false,
       DateTime? published = null)
    {
        return new Comment()
        {
            Id = id ?? Guid.NewGuid(),
            PostId = postId,
            AuthorId = authorId,
            Content = content,
            CreatedBy = createdBy,
            IsPublished = isPublished,
            Published = published ?? (isPublished ? DateTime.UtcNow : null),
            CreatedOn = DateTime.UtcNow,
        };
    }
}