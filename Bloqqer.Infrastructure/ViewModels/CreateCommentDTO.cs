using System.Text.Json.Serialization;

namespace Bloqqer.Infrastructure.ViewModels;

public class CreateCommentDTO
{
    public required Guid PostId { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }
}