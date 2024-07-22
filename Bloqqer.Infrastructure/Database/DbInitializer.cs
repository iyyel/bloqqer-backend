using Bloqqer.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloqqer.Infrastructure.Database;

public sealed class DbInitializer(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder modelBuilder = modelBuilder;

    public void Seed()
    {
        SeedAdminUser();
        SeedRegularUser();
    }

    private void SeedAdminUser()
    {
        var adminUserId = Guid.NewGuid();
        var adminBloqId = Guid.NewGuid();
        var adminPostId1 = Guid.NewGuid();
        var adminPostId2 = Guid.NewGuid();
        var adminPost1CommentId1 = Guid.NewGuid();
        var adminPost1CommentId2 = Guid.NewGuid();
        var adminPost2CommentId = Guid.NewGuid();

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        // TODO: Make create methods for all model entities.
        // TODO: Merge data and infrastructure projects.
        var adminUser = new ApplicationUser
        {
            Id = adminUserId,
            UserName = "admin@iyyel.io",
            NormalizedUserName = "ADMIN@IYYEL.IO",
            Email = "admin@iyyel.io",
            NormalizedEmail = "ADMIN@IYYEL.IO",
            FirstName = "Admin",
            MiddleName = "",
            LastName = "",
            PhoneNumber = "21212121",
            LockoutEnabled = false,
            EmailConfirmed = true,
            SecurityStamp = "admin",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            AccessFailedCount = 0,
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now,
        };
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin");

        var adminBloq = new Bloq
        {
            Id = adminBloqId,
            ApplicationUserId = adminUserId,
            Title = "Admin Seed Bloq Title",
            Description = "Admin Seed Bloq Description",
            IsPublished = false,
            IsPrivate = false,
            Posts = [],
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        var adminPost1 = new Post
        {
            Id = adminPostId1,
            BloqId = adminBloqId,
            ApplicationUserId = adminUserId,
            Title = "Admin Seed Bloq Post 1/2",
            Description = "Admin Seed Bloq Post 1/2 Description",
            Content = "Admin Seed Bloq Post 1/2 Content",
            IsPublished = true,
            Comments = [],
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        var adminPost2 = new Post
        {
            Id = adminPostId2,
            BloqId = adminBloqId,
            ApplicationUserId = adminUserId,
            Title = "Admin Seed Bloq Post 2/2",
            Description = "Admin Seed Bloq Post 2/2 Description",
            Content = "Admin Seed Bloq Post 2/2 Content",
            IsPublished = true,
            Comments = [],
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        var adminPost1Comment1 = new Comment
        {
            Id = adminPost1CommentId1,
            PostId = adminPostId1,
            ApplicationUserId = adminUserId,
            Content = "Admin Seed Bloq Post 1 Comment 1/2",
            IsPublished = true,
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        var adminPost1Comment2 = new Comment
        {
            Id = adminPost1CommentId2,
            PostId = adminPostId1,
            ApplicationUserId = adminUserId,
            Content = "Admin Seed Bloq Post 1 Comment 2/2",
            IsPublished = true,
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        var adminPost2Comment = new Comment
        {
            Id = adminPost2CommentId,
            PostId = adminPostId2,
            ApplicationUserId = adminUserId,
            Content = "Admin Seed Bloq Post 2 Comment 1/1",
            IsPublished = true,
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        modelBuilder.Entity<ApplicationUser>().HasData(adminUser);
        modelBuilder.Entity<Bloq>().HasData(adminBloq);
        modelBuilder.Entity<Post>().HasData(adminPost1);
        modelBuilder.Entity<Post>().HasData(adminPost2);
        modelBuilder.Entity<Comment>().HasData(adminPost1Comment1);
        modelBuilder.Entity<Comment>().HasData(adminPost1Comment2);
        modelBuilder.Entity<Comment>().HasData(adminPost2Comment);
    }

    private void SeedRegularUser()
    {
        var userId = Guid.NewGuid();
        var bloqId = Guid.NewGuid();
        var postId = Guid.NewGuid();
        var commentId1 = Guid.NewGuid();
        var commentId2 = Guid.NewGuid();
        var commentId3 = Guid.NewGuid();

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        var user = new ApplicationUser
        {
            Id = userId,
            UserName = "mail@iyyel.io",
            NormalizedUserName = "MAIL@IYYEL.IO",
            Email = "mail@iyyel.io",
            NormalizedEmail = "MAIL@IYYEL.IO",
            FirstName = "Daniel",
            MiddleName = "",
            LastName = "Larsen",
            PhoneNumber = "20202020",
            LockoutEnabled = false,
            EmailConfirmed = true,
            SecurityStamp = "user",
            PhoneNumberConfirmed = false,
            TwoFactorEnabled = false,
            AccessFailedCount = 0,
            CreatedBy = "Seed",
            CreatedOn = DateTime.Now,
        };
        user.PasswordHash = passwordHasher.HashPassword(user, "user");

        var bloq = new Bloq
        {
            Id = bloqId,
            ApplicationUserId = userId,
            Title = "Daniel Seed Bloq Title",
            Description = "Daniel Seed Bloq Description",
            IsPublished = false,
            IsPrivate = false,
            Posts = [],
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        var post = new Post
        {
            Id = postId,
            BloqId = bloqId,
            ApplicationUserId = userId,
            Title = "Daniel Seed Bloq Post 1/1",
            Description = "Daniel Seed Bloq Post 1/1 Description",
            Content = "Daniel Seed Bloq Post 1/1 Content",
            IsPublished = true,
            Comments = [],
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        var comment1 = new Comment
        {
            Id = commentId1,
            PostId = postId,
            ApplicationUserId = userId,
            Content = "Daniel Seed Bloq Post Comment 1/3",
            IsPublished = true,
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        var comment2 = new Comment
        {
            Id = commentId2,
            PostId = postId,
            ApplicationUserId = userId,
            Content = "Daniel Seed Bloq Post Comment 2/3",
            IsPublished = true,
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        var comment3 = new Comment
        {
            Id = commentId3,
            PostId = postId,
            ApplicationUserId = userId,
            Content = "Daniel Seed Bloq Post Comment 3/3",
            IsPublished = true,
            CreatedBy = "Seed",
            CreatedOn = DateTime.UtcNow,
        };

        modelBuilder.Entity<ApplicationUser>().HasData(user);
        modelBuilder.Entity<Bloq>().HasData(bloq);
        modelBuilder.Entity<Post>().HasData(post);
        modelBuilder.Entity<Comment>().HasData(comment1);
        modelBuilder.Entity<Comment>().HasData(comment2);
        modelBuilder.Entity<Comment>().HasData(comment3);
    }
}