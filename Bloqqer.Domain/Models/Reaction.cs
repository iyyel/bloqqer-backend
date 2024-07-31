using System.Text.Json.Serialization;

namespace Bloqqer.Domain.Models;

public class Reaction : BaseEntity<Guid>
{
    public Guid? BloqId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual Bloq? Bloq { get; set; }

    public Guid? PostId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual Post? Post { get; set; }

    public Guid? CommentId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual Comment? Comment { get; set; }

    public Guid? ReactorId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual ApplicationUser? Reactor { get; set; }

    // TODO: Is there a better way to have a 'Create' method? This is not very readable when invoked.
    // Object initializion syntax is more readable.
    public static Reaction Create(
        Guid reactorId,
        Guid createdBy,
        Guid? bloqId = null,
        Guid? postId = null,
        Guid? commentId = null,
        Guid? id = null
      )
    {
        if (bloqId is null && postId is null && commentId is null)
        {
            throw new ArgumentException("At least one id must be provided.");
        }

        return new Reaction()
        {
            Id = id ?? Guid.NewGuid(),
            BloqId = bloqId,
            PostId = postId,
            CommentId = commentId,
            ReactorId = reactorId,
            CreatedBy = createdBy,
            CreatedOn = DateTime.UtcNow,
        };
    }
}