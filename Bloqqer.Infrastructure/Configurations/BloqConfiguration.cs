using Bloqqer.Infrastructure.Models;
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
            .HasMaxLength(Bloq.MaxTitleLength);

        builder.Property(b => b.Description)
            .HasMaxLength(Bloq.MaxDescriptionLength);

        builder.HasMany(b => b.Posts)
            .WithOne(p => p.Bloq)
            .HasForeignKey(p => p.BloqId)
            .HasPrincipalKey(b => b.Id);

        builder.HasMany(b => b.Reactions)
            .WithOne(r => r.Bloq)
            .HasForeignKey(r => r.BloqId)
            .HasPrincipalKey(a => a.Id);

        builder.HasOne(b => b.Author)
            .WithMany(a => a.Bloqs)
            .HasForeignKey(b => b.AuthorId)
            .HasPrincipalKey(a => a.Id);
    }
}