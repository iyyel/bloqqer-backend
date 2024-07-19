using FlashCards.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FlashCards.DataAccess.Configurations;

public sealed class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder.Property(a => a.FirstName)
            .HasMaxLength(ApplicationUser.MaxFirstNameLength);

        builder.Property(a => a.MiddleName)
            .HasMaxLength(ApplicationUser.MaxMiddleNameLength);

        builder.Property(a => a.LastName)
            .HasMaxLength(ApplicationUser.MaxLastNameLength);

        builder.HasMany(a => a.FlashCardSets)
            .WithOne(f => f.ApplicationUser)
            .HasForeignKey(f => f.ApplicationUserId)
            .HasPrincipalKey(a => a.Id);
    }
}