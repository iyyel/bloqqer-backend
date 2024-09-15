using Bloqqer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloqqer.Infrastructure.Configurations;

public sealed class FollowConfiguration : IEntityTypeConfiguration<Follow>
{
    public void Configure(EntityTypeBuilder<Follow> builder)
    {
        // TODO: Constants?
        builder.ToTable("Bloqqer.Follows");

        builder.HasOne(f => f.Follower)
            .WithMany(a => a.Followers)
            .HasForeignKey(f => f.FollowerId)
            .HasPrincipalKey(a => a.Id);

        builder.HasOne(f => f.Followed)
            .WithMany(a => a.Following)
            .HasForeignKey(f => f.FollowedId)
            .HasPrincipalKey(a => a.Id)
            .OnDelete(DeleteBehavior.Restrict);
    }
}