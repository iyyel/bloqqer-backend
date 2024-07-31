using System.Text.Json.Serialization;

namespace Bloqqer.Domain.Models;

public class Post : BaseEntity<Guid>
{
    public Guid? BloqId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public Bloq? Bloq { get; set; }

    public required Guid AuthorId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual ApplicationUser? Author { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public required virtual ICollection<Comment> Comments { get; set; }

    public required virtual ICollection<Reaction> Reactions { get; set; }

    // TODO: Is there a better way to have a 'Create' method? This is not very readable when invoked.
    // Object initializion syntax is more readable.
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
            Reactions = [],
        };
    }
}