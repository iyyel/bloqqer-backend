using Bloqqer.DataAccess.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloqqer.DataAccess;

public sealed class DbInitializer(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder modelBuilder = modelBuilder;

    public void Seed()
    {
        SeedUsers();
        SeedRoles();
        SeedBloqs();
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

    private void SeedBloqs()
    {
        var bloq = new Bloq()
        {
            Id = Guid.NewGuid(),
            Title = "Bloq title",
            Description = "Bloq description",
            IsPublished = true,
            Published = DateTime.UtcNow,
            IsPrivate = false,
            Posts = [],
        };

        modelBuilder.Entity<Bloq>().HasData(bloq);
    }
}