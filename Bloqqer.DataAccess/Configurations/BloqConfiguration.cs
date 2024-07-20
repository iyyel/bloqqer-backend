using Bloqqer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloqqer.DataAccess.Configurations;

public sealed class BloqConfiguration : IEntityTypeConfiguration<Bloq>
{
    public void Configure(EntityTypeBuilder<Bloq> builder)
    {
        builder.Property(b => b.Title)
            .HasMaxLength(Bloq.MaxTitleLength);

        builder.Property(b => b.Description)
            .HasMaxLength(Bloq.MaxDescriptionLength);
        /*
        builder.HasMany(b => b.Posts)
            .WithOne(p => p.Bloq)
            .HasForeignKey(p => p.BloqId)
            .HasPrincipalKey(b => b.Id);
        */
        builder.HasOne(b => b.Author)
            .WithMany(a => a.Bloqs)
            .HasForeignKey(b => b.AuthorId)
            .HasPrincipalKey(a => a.Id);
    }
}