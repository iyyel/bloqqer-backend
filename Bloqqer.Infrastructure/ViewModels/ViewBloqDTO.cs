using Bloqqer.Infrastructure.Models;

namespace Bloqqer.Infrastructure.ViewModels;

public class ViewBloqDTO
{
    public required Guid BloqId { get; set; }

    public required Guid AuthorId { get; set; }

    public required string Title { get; set; }

    public required string Description { get; set; }

    public required bool IsPrivate { get; set; }

    public required bool IsPublished { get; set; }

    public DateTime? Published { get; set; }

    public required ICollection<Post> Posts { get; set; }
}