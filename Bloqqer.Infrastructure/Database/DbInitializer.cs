using Bloqqer.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloqqer.Infrastructure.Database;

public sealed class DbInitializer(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder modelBuilder = modelBuilder;

    private readonly Guid systemGuid = new("2afb7b32-9305-4c43-90d3-78412603e4ff");
    private readonly Guid adminUserGuid = new("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765");
    private readonly Guid jamesUserGuid = new("de05b775-a344-497f-a091-643d267ff25d");

    public void Seed()
    {
        SeedAdminUser();
        SeedJamesUser();
    }

    private void SeedAdminUser()
    {
        var bloqGuid1 = new Guid("295efc76-56d6-4839-ada4-25924f912aa0");
        var bloqGuid2 = new Guid("f8d31b28-1c9a-43c0-aebd-19236af4422f");
        var postGuid1 = new Guid("0cb3379f-6bea-424d-ba0f-a44f4fa6a11a");
        var postGuid2 = new Guid("efab75ca-f1ac-4211-8076-e344b9c98025");
        var post1CommentGuid1 = new Guid("1af0038f-73a2-4fbb-867f-75a90cf33536");
        var post1CommentGuid2 = new Guid("180daba0-d465-40d0-bb01-68e0ac40b86c");
        var post2CommentGuid1 = new Guid("3e8f006d-04c7-4d2b-97a2-108de9b39b3a");
        var post2CommentGuid2 = new Guid("fcc41c42-f406-4b28-9b4f-c7e02ccb6380");
        var post1ReactionGuid1 = new Guid("7a8504bd-5204-4ff7-8473-9b8a625d5d52");
        var post1ReactionGuid2 = new Guid("0fe8f779-88d5-46dc-a705-48eabe7691da");

        var adminUser = new ApplicationUser
        {
            Id = adminUserGuid,
            FirstName = "admin",
            MiddleName = "",
            LastName = "",
            UserName = "admin",
            NormalizedUserName = "ADMIN",
            Email = "admin@iyyel.io",
            NormalizedEmail = "ADMIN@IYYEL.IO",
            PhoneNumber = "21212121",
            SecurityStamp = "admin",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            LockoutEnabled = false,
            TwoFactorEnabled = false,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var passwordHasher = new PasswordHasher<ApplicationUser>();
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin");

        var adminBloq1 = new Bloq
        {
            Id = bloqGuid1,
            AuthorId = adminUser.Id,
            Title = "Admin Seed Bloq Title 1/2",
            Description = "Admin Seed Bloq Description 1/2",
            IsPrivate = false,
            IsPublished = true,
            Published = DateTime.UtcNow,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var adminBloq2 = new Bloq
        {
            Id = bloqGuid2,
            AuthorId = adminUser.Id,
            Title = "Admin Seed Bloq Title 2/2",
            Description = "Admin Seed Bloq Description 2/2",
            IsPrivate = true,
            IsPublished = false,
            Published = null,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var adminPost1 = new Post
        {
            Id = postGuid1,
            BloqId = adminBloq1.Id,
            AuthorId = adminUser.Id,
            Title = "Admin Seed Bloq Post 1/2",
            Description = "Admin Seed Bloq Post 1/2 Description",
            Content = "Admin Seed Bloq Post 1/2 Content",
            IsPublished = true,
            Published = DateTime.UtcNow,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var adminPost1Reaction1 = new Reaction
        {
            Id = post1ReactionGuid1,
            AuthorId = adminUser.Id,
            PostId = adminPost1.Id,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var adminPost1Reaction2 = new Reaction
        {
            Id = post1ReactionGuid2,
            AuthorId = adminUser.Id,
            PostId = adminPost1.Id,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var adminPost2 = new Post
        {
            Id = postGuid2,
            BloqId = adminBloq1.Id,
            AuthorId = adminUser.Id,
            Title = "Admin Seed Bloq Post 2/2",
            Description = "Admin Seed Bloq Post 2/2 Description",
            Content = "Admin Seed Bloq Post 2/2 Content",
            IsPublished = false,
            Published = null,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var adminPost1Comment1 = new Comment
        {
            Id = post1CommentGuid1,
            PostId = adminPost1.Id,
            AuthorId = adminUser.Id,
            Content = "Admin Seed Bloq Post 1 Comment 1/2",
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var adminPost1Comment2 = new Comment
        {
            Id = post1CommentGuid2,
            PostId = adminPost1.Id,
            AuthorId = adminUser.Id,
            Content = "Admin Seed Bloq Post 1 Comment 2/2",
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var adminPost2Comment1 = new Comment
        {
            Id = post2CommentGuid1,
            PostId = adminPost2.Id,
            AuthorId = adminUser.Id,
            Content = "Admin Seed Bloq Post 2 Comment 1/2",
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null,
        };

        var adminPost2Comment2 = new Comment
        {
            Id = post2CommentGuid2,
            PostId = adminPost2.Id,
            AuthorId = adminUser.Id,
            Content = "Admin Seed Bloq Post 2 Comment 2/2",
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        modelBuilder.Entity<ApplicationUser>().HasData(adminUser);
        modelBuilder.Entity<Bloq>().HasData(adminBloq1, adminBloq2);
        modelBuilder.Entity<Post>().HasData(adminPost1, adminPost2);
        modelBuilder.Entity<Comment>().HasData(adminPost1Comment1, adminPost1Comment2, adminPost2Comment1, adminPost2Comment2);
        modelBuilder.Entity<Reaction>().HasData(adminPost1Reaction1, adminPost1Reaction2);
    }

    private void SeedJamesUser()
    {
        var bloqGuid = new Guid("dc5b12fd-f5a3-4a04-a6e0-c4cd552cd6b5");
        var postGuid1 = new Guid("0afda5fc-0a56-45b6-a983-3018048c204a");
        var postGuid2 = new Guid("f298d1f6-9ae6-477c-af37-173f959cdd1c");
        var post1CommentGuid1 = new Guid("d1cd67d2-67e5-4c6f-aabb-cb4056dd5064");
        var post1CommentGuid2 = new Guid("49304138-ec9e-495e-8774-d4b2b64781ce");
        var post1CommentGuid3 = new Guid("679dee46-f2f2-4859-bedc-7d542eae5089");
        var post1ReactionGuid1 = new Guid("7a8504bd-5204-4ff7-8473-9b8a625d5d5a");
        var post1ReactionGuid2 = new Guid("0fe8f779-88d5-46dc-a705-48eabe7691de");
        var comment1ReactionGuid1 = new Guid("981f0e58-66df-4329-add8-3eaba8ae51d3");
        var followAdminGuid = new Guid("aac1463f-f051-4407-8ee6-f23431e9ccaa");

        var jamesUser = new ApplicationUser
        {
            Id = jamesUserGuid,
            FirstName = "James",
            MiddleName = "Charles",
            LastName = "Butler",
            UserName = "james",
            NormalizedUserName = "JAMES",
            Email = "james@iyyel.io",
            NormalizedEmail = "JAMES@IYYEL.IO",
            PhoneNumber = "20202020",
            SecurityStamp = "james",
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            LockoutEnabled = false,
            TwoFactorEnabled = false,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var passwordHasher = new PasswordHasher<ApplicationUser>();
        jamesUser.PasswordHash = passwordHasher.HashPassword(jamesUser, "james");

        var bloq = new Bloq
        {
            Id = bloqGuid,
            AuthorId = jamesUser.Id,
            Title = "James Seed Bloq Title 1/1",
            Description = "James Seed Bloq Description 1/1",
            IsPrivate = false,
            IsPublished = true,
            Published = DateTime.UtcNow,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var post1 = new Post
        {
            Id = postGuid1,
            BloqId = bloq.Id,
            AuthorId = jamesUser.Id,
            Title = "James Seed Bloq Post 1/2",
            Description = "James Seed Bloq Post 1/2 Description",
            Content = "James Seed Bloq Post 1/2 Content",
            IsPublished = true,
            Published = DateTime.UtcNow,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var post1Reaction1 = new Reaction
        {
            Id = post1ReactionGuid1,
            AuthorId = adminUserGuid,
            PostId = postGuid1,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var post1Reaction2 = new Reaction
        {
            Id = post1ReactionGuid2,
            AuthorId = adminUserGuid,
            PostId = postGuid1,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var post2 = new Post
        {
            Id = postGuid2,
            BloqId = bloq.Id,
            AuthorId = jamesUser.Id,
            Title = "James Seed Bloq Post 2/2",
            Description = "James Seed Bloq Post 2/2 Description",
            Content = "James Seed Bloq Post 2/2 Content",
            IsPublished = false,
            Published = null,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var post1Comment1 = new Comment
        {
            Id = post1CommentGuid1,
            PostId = postGuid1,
            AuthorId = jamesUser.Id,
            Content = "James Seed Bloq Post 1 Comment 1/3",
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var comment1Reaction1 = new Reaction
        {
            Id = comment1ReactionGuid1,
            AuthorId = adminUserGuid,
            CommentId = post1Comment1.Id,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var post1Comment2 = new Comment
        {
            Id = post1CommentGuid2,
            PostId = postGuid1,
            AuthorId = jamesUser.Id,
            Content = "James Seed Bloq Post 1 Comment 2/3",
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var post1Comment3 = new Comment
        {
            Id = post1CommentGuid3,
            PostId = postGuid1,
            AuthorId = jamesUser.Id,
            Content = "James Seed Bloq Post 1 Comment 3/3",
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        var followAdmin = new Follow
        {
            Id = followAdminGuid,
            FollowerId = jamesUser.Id,
            FollowedId = adminUserGuid,
            CreatedBy = systemGuid,
            CreatedOn = DateTime.UtcNow,
            ModifiedBy = null,
            ModifiedOn = null,
            RemovedBy = null,
            RemovedOn = null
        };

        modelBuilder.Entity<ApplicationUser>().HasData(jamesUser);
        modelBuilder.Entity<Bloq>().HasData(bloq);
        modelBuilder.Entity<Post>().HasData(post1, post2);
        modelBuilder.Entity<Comment>().HasData(post1Comment1, post1Comment2, post1Comment3);
        modelBuilder.Entity<Follow>().HasData(followAdmin);
        modelBuilder.Entity<Reaction>().HasData(post1Reaction1, post1Reaction2, comment1Reaction1);
    }
}