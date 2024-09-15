using Bloqqer.Domain.Constants;
using Bloqqer.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloqqer.Infrastructure.Configurations;

public sealed class BloqConfiguration : IEntityTypeConfiguration<Bloq>
{
    public void Configure(EntityTypeBuilder<Bloq> builder)
    {
        // TODO: Constants?
        builder.ToTable("Bloqqer.Bloqs");

        builder.Property(b => b.Title)
            .HasMaxLength(MaxLengths.Bloq.Title);

        builder.Property(b => b.Description)
            .HasMaxLength(MaxLengths.Bloq.Description);

        builder.HasMany(b => b.Posts)
            .WithOne(p => p.Bloq)
            .HasForeignKey(p => p.BloqId)
            .HasPrincipalKey(b => b.Id);

        builder.HasMany(b => b.Reactions)
            .WithOne(r => r.Bloq)
            .HasForeignKey(r => r.BloqId)
            .HasPrincipalKey(a => a.Id);

        builder.HasOne(b => b.Author)
            .WithMany(a => a.AuthoredBloqs)
            .HasForeignKey(b => b.AuthorId)
            .HasPrincipalKey(a => a.Id);
    }
}