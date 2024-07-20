using Bloqqer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloqqer.DataAccess.Configurations;

public sealed class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.Property(p => p.Title)
            .HasMaxLength(Post.MaxTitleLength);

        builder.Property(p => p.Description)
            .HasMaxLength(Post.MaxDescriptionLength);

        builder.Property(p => p.Content)
            .HasMaxLength(Post.MaxContentLength);

        builder.HasMany(p => p.Comments)
            .WithOne(c => c.Post)
            .HasForeignKey(c => c.PostId)
            .HasPrincipalKey(p => p.Id);

        builder.HasOne(p => p.Author)
            .WithMany(a => a.Posts)
            .HasForeignKey(p => p.AuthorId)
            .HasPrincipalKey(a => a.Id);
    }
}