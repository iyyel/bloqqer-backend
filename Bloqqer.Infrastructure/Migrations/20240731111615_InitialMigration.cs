using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bloqqer.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bloqqer.ApplicationUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloqqer.ApplicationUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Bloqqer.ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Bloqqer.ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Bloqqer.ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Bloqqer.ApplicationUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bloqqer.Bloqs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloqqer.Bloqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloqqer.Bloqs_Bloqqer.ApplicationUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bloqqer.Follows",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FollowedId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FollowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloqqer.Follows", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloqqer.Follows_Bloqqer.ApplicationUsers_FollowedId",
                        column: x => x.FollowedId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bloqqer.Follows_Bloqqer.ApplicationUsers_FollowerId",
                        column: x => x.FollowerId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bloqqer.Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloqqer.Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloqqer.Posts_Bloqqer.ApplicationUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bloqqer.Posts_Bloqqer.Bloqs_BloqId",
                        column: x => x.BloqId,
                        principalTable: "Bloqqer.Bloqs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bloqqer.Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloqqer.Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloqqer.Comments_Bloqqer.ApplicationUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bloqqer.Comments_Bloqqer.Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Bloqqer.Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Bloqqer.Reactions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CommentId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ReactorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RemovedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemovedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloqqer.Reactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloqqer.Reactions_Bloqqer.ApplicationUsers_ReactorId",
                        column: x => x.ReactorId,
                        principalTable: "Bloqqer.ApplicationUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bloqqer.Reactions_Bloqqer.Bloqs_BloqId",
                        column: x => x.BloqId,
                        principalTable: "Bloqqer.Bloqs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bloqqer.Reactions_Bloqqer.Comments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Bloqqer.Comments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Bloqqer.Reactions_Bloqqer.Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Bloqqer.Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Bloqqer.ApplicationUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "ModifiedBy", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RemovedBy", "RemovedOn", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), 0, "be50b958-be10-46ed-8d20-c620f1f2e755", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 297, DateTimeKind.Utc).AddTicks(6099), "admin@iyyel.io", true, "Admin", "", false, null, "", new Guid("00000000-0000-0000-0000-000000000000"), null, "ADMIN@IYYEL.IO", "ADMIN@IYYEL.IO", "AQAAAAIAAYagAAAAEALlHDA5VjykLvTkh6UNcKsRtouHxfNrUZdZUXMnMEZtOyMwzbn0SbJRwGKU+i981Q==", "21212121", true, new Guid("00000000-0000-0000-0000-000000000000"), null, "admin", false, "admin@iyyel.io" },
                    { new Guid("de05b775-a344-497f-a091-643d267ff25d"), 0, "b1226a26-8d18-4cc4-9847-02ecb0d0c5aa", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4607), "james@butler.xyz", true, "James", "Butler", false, null, "", new Guid("00000000-0000-0000-0000-000000000000"), null, "JAMES@BUTLER.XYZ", "JAMES@BUTLER.XYZ", "AQAAAAIAAYagAAAAEN2biABYwSRVg75UPu+udNV3vBNyMtvxIcgq2MaaJBz8bbQwECQv3JHmxyS2axLJ0g==", "23232323", true, new Guid("00000000-0000-0000-0000-000000000000"), null, "james", false, "james@butler.xyz" }
                });

            migrationBuilder.InsertData(
                table: "Bloqqer.Bloqs",
                columns: new[] { "Id", "AuthorId", "CreatedBy", "CreatedOn", "Description", "IsPrivate", "IsPublished", "ModifiedBy", "ModifiedOn", "Published", "RemovedBy", "RemovedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("295efc76-56d6-4839-ada4-25924f912aa0"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(2514), "Admin Seed Bloq Description 1/2", false, true, new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(2513), new Guid("00000000-0000-0000-0000-000000000000"), null, "Admin Seed Bloq Title 1/2" },
                    { new Guid("dc5b12fd-f5a3-4a04-a6e0-c4cd552cd6b5"), new Guid("de05b775-a344-497f-a091-643d267ff25d"), new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9329), "James Seed Bloq Description", false, true, new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9329), new Guid("00000000-0000-0000-0000-000000000000"), null, "James Seed Bloq Title" },
                    { new Guid("f8d31b28-1c9a-43c0-aebd-19236af4422f"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4332), "Admin Seed Bloq Description 2/2", true, false, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "Admin Seed Bloq Title 2/2" }
                });

            migrationBuilder.InsertData(
                table: "Bloqqer.Follows",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "FollowedId", "FollowerId", "ModifiedBy", "ModifiedOn", "RemovedBy", "RemovedOn" },
                values: new object[] { new Guid("aac1463f-f051-4407-8ee6-f23431e9ccaa"), new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9357), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), new Guid("de05b775-a344-497f-a091-643d267ff25d"), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("00000000-0000-0000-0000-000000000000"), null });

            migrationBuilder.InsertData(
                table: "Bloqqer.Posts",
                columns: new[] { "Id", "AuthorId", "BloqId", "Content", "CreatedBy", "CreatedOn", "Description", "IsPublished", "ModifiedBy", "ModifiedOn", "Published", "RemovedBy", "RemovedOn", "Title" },
                values: new object[,]
                {
                    { new Guid("0afda5fc-0a56-45b6-a983-3018048c204a"), new Guid("de05b775-a344-497f-a091-643d267ff25d"), new Guid("dc5b12fd-f5a3-4a04-a6e0-c4cd552cd6b5"), "James Seed Bloq Post 1/2 Content", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9335), "James Seed Bloq Post 1/2 Description", true, new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9334), new Guid("00000000-0000-0000-0000-000000000000"), null, "James Seed Bloq Post 1/2" },
                    { new Guid("0cb3379f-6bea-424d-ba0f-a44f4fa6a11a"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), new Guid("295efc76-56d6-4839-ada4-25924f912aa0"), "Admin Seed Bloq Post 1/2 Content", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4341), "Admin Seed Bloq Post 1/2 Description", true, new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4340), new Guid("00000000-0000-0000-0000-000000000000"), null, "Admin Seed Bloq Post 1/2" },
                    { new Guid("efab75ca-f1ac-4211-8076-e344b9c98025"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), new Guid("295efc76-56d6-4839-ada4-25924f912aa0"), "Admin Seed Bloq Post 2/2 Content", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4346), "Admin Seed Bloq Post 2/2 Description", false, new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("00000000-0000-0000-0000-000000000000"), null, "Admin Seed Bloq Post 2/2" },
                    { new Guid("f298d1f6-9ae6-477c-af37-173f959cdd1c"), new Guid("de05b775-a344-497f-a091-643d267ff25d"), new Guid("dc5b12fd-f5a3-4a04-a6e0-c4cd552cd6b5"), "James Seed Bloq Post 2/2 Content", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9345), "James Seed Bloq Post 2/2 Description", true, new Guid("00000000-0000-0000-0000-000000000000"), null, new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9344), new Guid("00000000-0000-0000-0000-000000000000"), null, "James Seed Bloq Post 2/2" }
                });

            migrationBuilder.InsertData(
                table: "Bloqqer.Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedBy", "CreatedOn", "IsPublished", "ModifiedBy", "ModifiedOn", "PostId", "Published", "RemovedBy", "RemovedOn" },
                values: new object[,]
                {
                    { new Guid("180daba0-d465-40d0-bb01-68e0ac40b86c"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), "Admin Seed Bloq Post 1 Comment 2/2", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4354), false, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("0cb3379f-6bea-424d-ba0f-a44f4fa6a11a"), null, new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("1af0038f-73a2-4fbb-867f-75a90cf33536"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), "Admin Seed Bloq Post 1 Comment 1/2", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4352), true, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("0cb3379f-6bea-424d-ba0f-a44f4fa6a11a"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4351), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("3e8f006d-04c7-4d2b-97a2-108de9b39b3a"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), "Admin Seed Bloq Post 2 Comment 1/2", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4356), true, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("efab75ca-f1ac-4211-8076-e344b9c98025"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4355), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("49304138-ec9e-495e-8774-d4b2b64781ce"), new Guid("de05b775-a344-497f-a091-643d267ff25d"), "James Seed Bloq Post 1 Comment 2/3", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9351), true, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("0afda5fc-0a56-45b6-a983-3018048c204a"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9351), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("679dee46-f2f2-4859-bedc-7d542eae5089"), new Guid("de05b775-a344-497f-a091-643d267ff25d"), "James Seed Bloq Post 1 Comment 3/3", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9353), true, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("0afda5fc-0a56-45b6-a983-3018048c204a"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9352), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("d1cd67d2-67e5-4c6f-aabb-cb4056dd5064"), new Guid("de05b775-a344-497f-a091-643d267ff25d"), "James Seed Bloq Post 1 Comment 1/3", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9348), true, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("0afda5fc-0a56-45b6-a983-3018048c204a"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9348), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("fcc41c42-f406-4b28-9b4f-c7e02ccb6380"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), "Admin Seed Bloq Post 2 Comment 2/2", new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 335, DateTimeKind.Utc).AddTicks(4357), false, new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("efab75ca-f1ac-4211-8076-e344b9c98025"), null, new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.InsertData(
                table: "Bloqqer.Reactions",
                columns: new[] { "Id", "BloqId", "CommentId", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "PostId", "ReactorId", "RemovedBy", "RemovedOn" },
                values: new object[,]
                {
                    { new Guid("0fe8f779-88d5-46dc-a705-48eabe7691de"), null, null, new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9343), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("0afda5fc-0a56-45b6-a983-3018048c204a"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("7a8504bd-5204-4ff7-8473-9b8a625d5d52"), null, null, new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9341), new Guid("00000000-0000-0000-0000-000000000000"), null, new Guid("0afda5fc-0a56-45b6-a983-3018048c204a"), new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), new Guid("00000000-0000-0000-0000-000000000000"), null },
                    { new Guid("981f0e58-66df-4329-add8-3eaba8ae51d3"), null, new Guid("d1cd67d2-67e5-4c6f-aabb-cb4056dd5064"), new Guid("2afb7b32-9305-4c43-90d3-78412603e4ff"), new DateTime(2024, 7, 31, 11, 16, 15, 372, DateTimeKind.Utc).AddTicks(9350), new Guid("00000000-0000-0000-0000-000000000000"), null, null, new Guid("c108f0d4-7f9f-49eb-8a18-9f9bd81e1765"), new Guid("00000000-0000-0000-0000-000000000000"), null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Bloqqer.ApplicationUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Bloqqer.ApplicationUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Bloqs_AuthorId",
                table: "Bloqqer.Bloqs",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Comments_AuthorId",
                table: "Bloqqer.Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Comments_PostId",
                table: "Bloqqer.Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Follows_FollowedId",
                table: "Bloqqer.Follows",
                column: "FollowedId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Follows_FollowerId",
                table: "Bloqqer.Follows",
                column: "FollowerId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Posts_AuthorId",
                table: "Bloqqer.Posts",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Posts_BloqId",
                table: "Bloqqer.Posts",
                column: "BloqId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Reactions_BloqId",
                table: "Bloqqer.Reactions",
                column: "BloqId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Reactions_CommentId",
                table: "Bloqqer.Reactions",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Reactions_PostId",
                table: "Bloqqer.Reactions",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqqer.Reactions_ReactorId",
                table: "Bloqqer.Reactions",
                column: "ReactorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Bloqqer.Follows");

            migrationBuilder.DropTable(
                name: "Bloqqer.Reactions");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Bloqqer.Comments");

            migrationBuilder.DropTable(
                name: "Bloqqer.Posts");

            migrationBuilder.DropTable(
                name: "Bloqqer.Bloqs");

            migrationBuilder.DropTable(
                name: "Bloqqer.ApplicationUsers");
        }
    }
}
