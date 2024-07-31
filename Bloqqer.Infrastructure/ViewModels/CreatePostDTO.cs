namespace Bloqqer.Infrastructure.ViewModels;

// TODO: Turn all view models into records?
public class CreatePostDTO
{
    public required Guid BloqId { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required string Content { get; set; }

    public required bool IsPublished { get; set; }
}