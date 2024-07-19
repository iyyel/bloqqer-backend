using FlashCards.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.DataAccess;

public sealed class DbInitializer(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder modelBuilder = modelBuilder;

    public void Seed()
    {
        var systemUser = new ApplicationUser()
        {
            Id = Guid.NewGuid().ToString(),
            UserName = "System",
            Email = "system@iyyel.io"
        };

        modelBuilder.Entity<ApplicationUser>().HasData(systemUser);
    }
}