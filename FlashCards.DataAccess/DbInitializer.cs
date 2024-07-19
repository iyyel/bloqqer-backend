using FlashCards.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.DataAccess;

public sealed class DbInitializer(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder modelBuilder = modelBuilder;

    public void Seed()
    {
        SeedUsers();
        SeedRoles();
        SeedFlashCardSets();
    }

    private void SeedUsers()
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
    }

    private void SeedRoles()
    {
        modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
        {
            Id = Guid.NewGuid(),
            Name = ApplicationRole.SuperUser
        });
        modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
        {
            Id = Guid.NewGuid(),
            Name = ApplicationRole.Admin
        });
        modelBuilder.Entity<ApplicationRole>().HasData(new ApplicationRole()
        {
            Id = Guid.NewGuid(),
            Name = ApplicationRole.User
        });
    }

    private void SeedFlashCardSets()
    {
        var flashCardSet1 = new FlashCardSet()
        {
            Id = Guid.NewGuid(),
            Title = "Set 1",
            FlashCards = [],
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now,
        };

        var flashCardSet2 = new FlashCardSet()
        {
            Id = Guid.NewGuid(),
            Title = "Set 1",
            FlashCards = [],
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now,
        };

        var flashCard1 = new FlashCard()
        {
            Id = Guid.NewGuid(),
            FrontText = "Front Text 1",
            BackText = "Back Text 1",
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now,
        };

        var flashCard2 = new FlashCard()
        {
            Id = Guid.NewGuid(),
            FrontText = "Front Text 2",
            BackText = "Back Text 2",
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now,
        };

        modelBuilder.Entity<FlashCardSet>().HasData(flashCardSet1, flashCardSet2);
        modelBuilder.Entity<FlashCard>().HasData(flashCard1, flashCard2);
    }
}