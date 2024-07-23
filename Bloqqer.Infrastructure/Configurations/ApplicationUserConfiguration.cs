using Bloqqer.Infrastructure.Models;
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
            .HasMaxLength(ApplicationUser.MaxFirstNameLength);

        builder.Property(a => a.MiddleName)
            .HasMaxLength(ApplicationUser.MaxMiddleNameLength);

        builder.Property(a => a.LastName)
            .HasMaxLength(ApplicationUser.MaxLastNameLength);

        builder.HasMany(a => a.Bloqs)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .HasPrincipalKey(a => a.Id);

        builder.HasMany(a => a.Posts)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId)
            .HasPrincipalKey(a => a.Id);

        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Author)
            .HasForeignKey(c => c.AuthorId)
            .HasPrincipalKey(a => a.Id);

        builder.HasMany(a => a.Reactions)
            .WithOne(r => r.Reactor)
            .HasForeignKey(c => c.ReactorId)
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