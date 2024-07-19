using FlashCards.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.DataAccess;

public sealed class DbInitializer(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder modelBuilder = modelBuilder;

    public void Seed()
    {
        var users = SeedUsers();
        SeedFlashCardSets(users);
    }

    private (ApplicationUser, ApplicationUser) SeedUsers()
    {
        var passwordHasher = new PasswordHasher<ApplicationUser>();

        var adminUser = new ApplicationUser()
        {
            Id = Guid.NewGuid(),
            UserName = "admin@iyyel.io",
            Email = "admin@iyyel.io",
            FirstName = "Admin",
            MiddleName = "",
            LastName = "",
            PhoneNumber = "21212121",
            NormalizedUserName = "ADMIN@IYYEL.IO",
            LockoutEnabled = false,
            EmailConfirmed = true,
            SecurityStamp = "admin",
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now,
        };
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin");

        var danielUser = new ApplicationUser()
        {
            Id = Guid.NewGuid(),
            UserName = "mail@iyyel.io",
            Email = "mail@iyyel.io",
            FirstName = "Daniel",
            MiddleName = "",
            LastName = "Larsen",
            PhoneNumber = "20202020",
            NormalizedUserName = "MAIL@IYYEL.IO",
            LockoutEnabled = false,
            EmailConfirmed = true,
            SecurityStamp = "daniel",
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now,
        };
        danielUser.PasswordHash = passwordHasher.HashPassword(danielUser, "1234");

        modelBuilder.Entity<ApplicationUser>().HasData(adminUser, danielUser);

        return (adminUser, danielUser);
    }

    private void SeedFlashCardSets((ApplicationUser adminUser, ApplicationUser danielUser) users)
    {
        var flashCardSet = new FlashCardSet()
        {
            Id = Guid.NewGuid(),
            ApplicationUserId = users.adminUser.Id,
            ApplicationUser = users.adminUser,
            Title = "Admin Set",
            FlashCards = [],
        };
        /*
        var flashCard = new FlashCard()
        {
            Id = Guid.NewGuid(),
            FlashCardSetId = flashCardSetId,
            FlashCardSet = flashCardSet,
            FrontText = "front text",
            BackText = "back text",
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now,
        };
        flashCards.Add(flashCard);
       */

        modelBuilder.Entity<FlashCardSet>().HasData(flashCardSet);
        // modelBuilder.Entity<FlashCard>().HasData(flashCard);
    }
}