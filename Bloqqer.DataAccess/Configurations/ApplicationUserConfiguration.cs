using Bloqqer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Bloqqer.DataAccess.Configurations;

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

        builder.HasMany(a => a.Bloqs)
            .WithOne(b => b.Author)
            .HasForeignKey(b => b.AuthorId)
            .HasPrincipalKey(a => a.Id);
        /*
        builder.HasMany(a => a.Posts)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId)
            .HasPrincipalKey(a => a.Id);
        */
        /*
        builder.HasMany(a => a.Comments)
            .WithOne(c => c.Author)
            .HasForeignKey(c => c.AuthorId)
            .HasPrincipalKey(a => a.Id);
        */
    }
}