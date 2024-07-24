using System.Text.Json.Serialization;

namespace Bloqqer.Infrastructure.Models;

public class Comment : BaseEntity<Guid>
{
    public const int MaxContentLength = 256;

    public Guid? PostId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual Post? Post { get; set; }

    public required Guid AuthorId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual ApplicationUser? Author { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public required virtual ICollection<Reaction> Reactions { get; set; }

    // TODO: Is there a better way to have a 'Create' method? This is not very readable when invoked.
    // Object initializion syntax is more readable.
    public static Comment Create(
       Guid postId,
       Guid authorId,
       string content,
       Guid createdBy,
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
            Reactions = [],
        };
    }
}