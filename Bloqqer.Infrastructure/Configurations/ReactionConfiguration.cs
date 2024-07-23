using Bloqqer.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloqqer.Infrastructure.Configurations;

public sealed class ReactionConfiguration : IEntityTypeConfiguration<Reaction>
{
    public void Configure(EntityTypeBuilder<Reaction> builder)
    {
        // TODO: Constants?
        builder.ToTable("Bloqqer.Reactions");

        builder.HasOne(r => r.Bloq)
            .WithMany(b => b.Reactions)
            .HasForeignKey(r => r.BloqId)
            .HasPrincipalKey(b => b.Id);

        builder.HasOne(r => r.Post)
            .WithMany(p => p.Reactions)
            .HasForeignKey(r => r.PostId)
            .HasPrincipalKey(p => p.Id);

        builder.HasOne(r => r.Comment)
            .WithMany(c => c.Reactions)
            .HasForeignKey(r => r.CommentId)
            .HasPrincipalKey(c => c.Id);

        builder.HasOne(r => r.Reactor)
            .WithMany(a => a.Reactions)
            .HasForeignKey(r => r.ReactorId)
            .HasPrincipalKey(a => a.Id);
    }
}