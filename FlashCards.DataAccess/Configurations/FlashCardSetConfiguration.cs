using FlashCards.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCards.DataAccess.Configurations;

public sealed class FlashCardSetConfiguration : IEntityTypeConfiguration<FlashCardSet>
{
    public void Configure(EntityTypeBuilder<FlashCardSet> builder)
    {
        builder.Property(f => f.Title)
            .HasMaxLength(FlashCardSet.MaxTitleLength);

        builder.HasMany(f => f.FlashCards)
            .WithOne(f => f.FlashCardSet)
            .HasForeignKey(f => f.FlashCardSetId)
            .HasPrincipalKey(f => f.Id);
    }
}