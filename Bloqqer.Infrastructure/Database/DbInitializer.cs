using Bloqqer.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Bloqqer.Infrastructure.Database;

public sealed class DbInitializer(ModelBuilder modelBuilder)
{
    private readonly ModelBuilder modelBuilder = modelBuilder;
    private readonly Guid systemGuid = new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff");

    public void Seed()
    {
        SeedAdminUser();
        SeedRegularUser();
        SeedAnotherRegularUser();
    }

    private void SeedAdminUser()
    {
        var userGuid = new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765");
        var bloqGuid1 = new Guid("295efc76-56d6-4839-ada4-25924f912aa0");
        var bloqGuid2 = new Guid("f8d31b28-1c9a-43c0-aebd-19236af4422f");
        var postGuid1 = new Guid("0cb3379f-6bea-424d-ba0f-a44f4fa6a11a");
        var postGuid2 = new Guid("efab75ca-f1ac-4211-8076-e344b9c98025");
        var post1CommentGuid1 = new Guid("1af0038f-73a2-4fbb-867f-75a90cf33536");
        var post1CommentGuid2 = new Guid("180daba0-d465-40d0-bb01-68e0ac40b86c");
        var post2CommentGuid1 = new Guid("3e8f006d-04c7-4d2b-97a2-108de9b39b3a");
        var post2CommentGuid2 = new Guid("fcc41c42-f406-4b28-9b4f-c7e02ccb6380");

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        var adminUser = ApplicationUser.Create(
            "admin@iyyel.io",
            "Admin",
            "21212121",
            "admin",
            systemGuid,
            userGuid
            );
        adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "admin");

        var adminBloq1 = Bloq.Create(
            adminUser.Id,
            "Admin Seed Bloq Title 1/2",
            "Admin Seed Bloq Description 1/2",
            systemGuid,
            false,
            bloqGuid1,
            true
            );

        var adminBloq2 = Bloq.Create(
            adminUser.Id,
            "Admin Seed Bloq Title 2/2",
            "Admin Seed Bloq Description 2/2",
            systemGuid,
            true,
            bloqGuid2,
            false
            );

        var adminPost1 = Post.Create(
            adminBloq1.Id,
            adminUser.Id,
            "Admin Seed Bloq Post 1/2",
            "Admin Seed Bloq Post 1/2 Description",
            "Admin Seed Bloq Post 1/2 Content",
            systemGuid,
            true,
            postGuid1
            );

        var adminPost2 = Post.Create(
            adminBloq1.Id,
            adminUser.Id,
            "Admin Seed Bloq Post 2/2",
            "Admin Seed Bloq Post 2/2 Description",
            "Admin Seed Bloq Post 2/2 Content",
            systemGuid,
            false,
            postGuid2
            );

        var adminPost1Comment1 = Comment.Create(
            postGuid1,
            userGuid,
            "Admin Seed Bloq Post 1 Comment 1/2",
            systemGuid,
            post1CommentGuid1,
            true
            );

        var adminPost1Comment2 = Comment.Create(
            postGuid1,
            userGuid,
            "Admin Seed Bloq Post 1 Comment 2/2",
            systemGuid,
            post1CommentGuid2,
            false
            );

        var adminPost2Comment1 = Comment.Create(
            postGuid2,
            userGuid,
            "Admin Seed Bloq Post 2 Comment 1/2",
            systemGuid,
            post2CommentGuid1,
            true
            );

        var adminPost2Comment2 = Comment.Create(
            postGuid2,
            userGuid,
            "Admin Seed Bloq Post 2 Comment 2/2",
            systemGuid,
            post2CommentGuid2,
            false
            );

        modelBuilder.Entity<ApplicationUser>().HasData(adminUser);
        modelBuilder.Entity<Bloq>().HasData(adminBloq1);
        modelBuilder.Entity<Bloq>().HasData(adminBloq2);
        modelBuilder.Entity<Post>().HasData(adminPost1);
        modelBuilder.Entity<Post>().HasData(adminPost2);
        modelBuilder.Entity<Comment>().HasData(adminPost1Comment1);
        modelBuilder.Entity<Comment>().HasData(adminPost1Comment2);
        modelBuilder.Entity<Comment>().HasData(adminPost2Comment1);
        modelBuilder.Entity<Comment>().HasData(adminPost2Comment2);
    }

    private void SeedRegularUser()
    {
        var userGuid = new Guid("de05b775-a344-497f-a091-643d267ff25d");
        var bloqGuid = new Guid("dc5b12fd-f5a3-4a04-a6e0-c4cd552cd6b5");
        var postGuid1 = new Guid("0afda5fc-0a56-45b6-a983-3018048c204a");
        var postGuid2 = new Guid("f298d1f6-9ae6-477c-af37-173f959cdd1c");
        var post1CommentGuid1 = new Guid("d1cd67d2-67e5-4c6f-aabb-cb4056dd5064");
        var post1CommentGuid2 = new Guid("49304138-ec9e-495e-8774-d4b2b64781ce");
        var post1CommentGuid3 = new Guid("679dee46-f2f2-4859-bedc-7d542eae5089");

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        var user = ApplicationUser.Create(
            "mail@iyyel.io",
            "Daniel",
            "20202020",
            "user",
            systemGuid,
            userGuid
            );
        user.PasswordHash = passwordHasher.HashPassword(user, "user");

        var bloq = Bloq.Create(
            userGuid,
            "Daniel Seed Bloq Title",
            "Daniel Seed Bloq Description",
            systemGuid,
            false,
            bloqGuid,
            true
            );

        var post1 = Post.Create(
            bloq.Id,
            user.Id,
            "Daniel Seed Bloq Post 1/2",
            "Daniel Seed Bloq Post 1/2 Description",
            "Daniel Seed Bloq Post 1/2 Content",
            systemGuid,
            true,
            postGuid1
            );

        var post2 = Post.Create(
            bloq.Id,
            user.Id,
            "Daniel Seed Bloq Post 2/2",
            "Daniel Seed Bloq Post 2/2 Description",
            "Daniel Seed Bloq Post 2/2 Content",
            systemGuid,
            true,
            postGuid2
            );

        var post1Comment1 = Comment.Create(
            postGuid1,
            userGuid,
            "Daniel Seed Bloq Post 1 Comment 1/3",
            systemGuid,
            post1CommentGuid1,
            true
            );

        var post1Comment2 = Comment.Create(
            postGuid1,
            userGuid,
            "Daniel Seed Bloq Post 1 Comment 2/3",
            systemGuid,
            post1CommentGuid2,
            true
            );

        var post1Comment3 = Comment.Create(
            postGuid1,
            userGuid,
            "Daniel Seed Bloq Post 1 Comment 3/3",
            systemGuid,
            post1CommentGuid3,
            true
            );

        modelBuilder.Entity<ApplicationUser>().HasData(user);
        modelBuilder.Entity<Bloq>().HasData(bloq);
        modelBuilder.Entity<Post>().HasData(post1);
        modelBuilder.Entity<Post>().HasData(post2);
        modelBuilder.Entity<Comment>().HasData(post1Comment1);
        modelBuilder.Entity<Comment>().HasData(post1Comment2);
        modelBuilder.Entity<Comment>().HasData(post1Comment3);
    }

    private void SeedAnotherRegularUser()
    {
        var userGuid = new Guid("5734941b-03c9-4416-9451-b32d2a0e4cc0");

        var passwordHasher = new PasswordHasher<ApplicationUser>();

        var user = ApplicationUser.Create(
            "james@butler.xyz",
            "James",
            "23232323",
            "james",
            systemGuid,
            userGuid,
            "Henrich",
            "Butler"
            );
        user.PasswordHash = passwordHasher.HashPassword(user, "user");

        modelBuilder.Entity<ApplicationUser>().HasData(user);
    }
}