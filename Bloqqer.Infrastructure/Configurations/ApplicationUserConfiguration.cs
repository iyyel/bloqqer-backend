using Bloqqer.Domain.Constants;
using Bloqqer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloqqer.Infrastructure.Configurations;

public sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        // TODO: Constants?
        builder.ToTable("Bloqqer.ApplicationUsers");

        builder.Property(a => a.FirstName)
            .HasMaxLength(MaxLengths.ApplicationUser.FirstName);

        builder.Property(a => a.MiddleName)
            .HasMaxLength(MaxLengths.ApplicationUser.MiddleName);

        builder.Property(a => a.LastName)
            .HasMaxLength(MaxLengths.ApplicationUser.LastName);

        builder.HasMany(a => a.AuthoredBloqs)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .HasPrincipalKey(a => a.Id);

        builder.HasMany(a => a.AuthoredPosts)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId)
            .HasPrincipalKey(a => a.Id);

        builder.HasMany(a => a.AuthoredComments)
            .WithOne(c => c.Author)
            .HasForeignKey(c => c.AuthorId)
            .HasPrincipalKey(a => a.Id);

        builder.HasMany(a => a.AuthoredReactions)
            .WithOne(r => r.Author)
            .HasForeignKey(c => c.AuthorId)
            .HasPrincipalKey(a => a.Id);

        builder.HasMany(a => a.Followers)
            .WithOne(f => f.Follower)
            .HasForeignKey(f => f.FollowerId)
            .HasPrincipalKey(a => a.Id);

        builder.HasMany(a => a.Following)
            .WithOne(f => f.Followed)
            .HasForeignKey(f => f.FollowedId)
            .HasPrincipalKey(a => a.Id);
    }
}