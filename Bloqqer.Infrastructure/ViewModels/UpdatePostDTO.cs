namespace Bloqqer.Infrastructure.ViewModels;

public class UpdatePostDTO
{
    public required Guid PostId { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }
}