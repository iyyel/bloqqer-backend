using Bloqqer.Domain.Constants;
using Bloqqer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloqqer.Infrastructure.Configurations;

public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        // TODO: Constants?
        builder.ToTable("Bloqqer.Posts");

        builder.Property(p => p.Title)
            .HasMaxLength(MaxLengths.Post.Title);

        builder.Property(p => p.Description)
            .HasMaxLength(MaxLengths.Post.Description);

        builder.Property(p => p.Content)
            .HasMaxLength(MaxLengths.Post.Content);

        builder.HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .HasPrincipalKey(p => p.Id);

        builder.HasMany(p => p.Reactions)
            .WithOne(r => r.Post)
            .HasForeignKey(r => r.PostId)
            .HasPrincipalKey(p => p.Id);

        builder.HasOne(p => p.Author)
            .WithMany(a => a.AuthoredPosts)
            .HasForeignKey(p => p.AuthorId)
            .HasPrincipalKey(a => a.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}