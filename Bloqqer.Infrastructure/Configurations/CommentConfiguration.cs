using Bloqqer.Domain.Constants;
using Bloqqer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloqqer.Infrastructure.Configurations;

public sealed class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        // TODO: Constants?
        builder.ToTable("Bloqqer.Comments");

        builder.Property(p => p.Content)
            .HasMaxLength(MaxLengths.Comment.Content);

        builder.HasMany(c => c.Reactions)
            .WithOne(r => r.Comment)
            .HasForeignKey(r => r.CommentId)
            .HasPrincipalKey(c => c.Id);

        builder.HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(p => p.PostId)
            .HasPrincipalKey(p => p.Id);

        builder.HasOne(c => c.Author)
            .WithMany(a => a.Comments)
            .HasForeignKey(c => c.AuthorId)
            .HasPrincipalKey(a => a.Id);
    }
}