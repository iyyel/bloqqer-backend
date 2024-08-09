using System.Text.Json.Serialization;

namespace Bloqqer.Domain.Models;

public class Follow : BaseEntity<Guid>
{
    public required Guid FollowerId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual ApplicationUser? Follower { get; set; }

    public Guid? FollowedId { get; set; }

    // TODO: Find a better solution for this JSON ignore. Use dedicated DTOs?
    [JsonIgnore]
    public virtual ApplicationUser? Followed { get; set; }

    // TODO: Is there a better way to have a 'Create' method? This is not very readable when invoked.
    // Object initializion syntax is more readable.
    public static Follow Create(
        Guid followerId,
        Guid followedId,
        Guid createdBy,
        Guid? id = null
      )
    {
        return new Follow()
        {
            Id = id ?? Guid.NewGuid(),
            FollowerId = followerId,
            FollowedId = followedId,
            CreatedBy = createdBy,
            CreatedOn = DateTime.UtcNow,
        };
    }
}