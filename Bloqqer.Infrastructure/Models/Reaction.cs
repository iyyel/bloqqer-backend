using System.Text.Json.Serialization;

namespace Bloqqer.Infrastructure.Models;

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
}