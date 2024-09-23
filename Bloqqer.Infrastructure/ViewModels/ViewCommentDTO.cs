﻿using Bloqqer.Domain.Models;

namespace Bloqqer.Infrastructure.ViewModels;

public class ViewCommentDTO
{
    public required Guid PostId { get; set; }

    public required Guid AuthorId { get; set; }

    public required string Content { get; set; }

    public ICollection<Reaction>? Reactions { get; set; }
}