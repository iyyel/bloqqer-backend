using FlashCards.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCards.DataAccess.Configurations;

public sealed class FlashCardConfiguration : IEntityTypeConfiguration<FlashCard>
{
    public void Configure(EntityTypeBuilder<FlashCard> builder)
    {
        builder.Property(f => f.FrontText)
            .HasMaxLength(FlashCard.MaxFrontTextLength);

        builder.Property(f => f.BackText)
            .HasMaxLength(FlashCard.MaxBackTextLength);

        builder.HasOne(f => f.FlashCardSet)
            .WithMany(f => f.FlashCards)
            .HasForeignKey(f => f.FlashCardSetId)
            .HasPrincipalKey(f => f.Id);
    }
}