using System.Text.Json.Serialization;

namespace Bloqqer.Domain.Models;

public class Bloq : BaseEntity<Guid>
{
    public required Guid AuthorId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual ApplicationUser? Author { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsPrivate { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public required virtual ICollection<Post> Posts { get; set; }

    public required virtual ICollection<Reaction> Reactions { get; set; }

    // TODO: Is there a better way to have a 'Create' method? This is not very readable when invoked.
    // Object initializion syntax is more readable.
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