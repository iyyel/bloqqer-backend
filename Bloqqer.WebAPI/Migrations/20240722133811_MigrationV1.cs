using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bloqqer.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class MigrationV1 : Migration
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    MiddleName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
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
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
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
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
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
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bloqs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bloqs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bloqs_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BloqId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    Content = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Posts_Bloqs_BloqId",
                        column: x => x.BloqId,
                        principalTable: "Bloqs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PostId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ApplicationUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    Published = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "MiddleName", "ModifiedBy", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("9ec5bf5a-8215-453b-ae4c-55ea4b337823"), 0, "294eee7c-5098-42e3-895d-9e006237ed31", "Seed", new DateTime(2024, 7, 22, 15, 38, 11, 578, DateTimeKind.Local).AddTicks(241), null, null, "mail@iyyel.io", true, "Daniel", "Larsen", false, null, "", null, null, "MAIL@IYYEL.IO", "MAIL@IYYEL.IO", "AQAAAAIAAYagAAAAEAcGagwcG9QQTXna8CF+ZzcYG1SkHpoGdH/6ZE1vbX9GRK7QebTii2X536VcfjTcEg==", "20202020", false, "user", false, "mail@iyyel.io" },
                    { new Guid("cbeca2b2-01d7-4014-aea3-f7c8a809a905"), 0, "62793c88-5f85-4785-8f4a-33ac29b8742d", "Seed", new DateTime(2024, 7, 22, 15, 38, 11, 540, DateTimeKind.Local).AddTicks(8391), null, null, "admin@iyyel.io", true, "Admin", "", false, null, "", null, null, "ADMIN@IYYEL.IO", "ADMIN@IYYEL.IO", "AQAAAAIAAYagAAAAEIUl3P0FncNsdrY9J9YE+pzXHoET6n/QQuUwZ5Ih42ij4FNt44FdqyAcDxDhUz7jqQ==", "21212121", false, "admin", false, "admin@iyyel.io" }
                });

            migrationBuilder.InsertData(
                table: "Bloqs",
                columns: new[] { "Id", "ApplicationUserId", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsPrivate", "IsPublished", "ModifiedBy", "ModifiedOn", "Published", "Title" },
                values: new object[,]
                {
                    { new Guid("954c3a03-9992-452a-8c22-f306d7ecbfcd"), new Guid("cbeca2b2-01d7-4014-aea3-f7c8a809a905"), "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 577, DateTimeKind.Utc).AddTicks(9686), null, null, "Admin Seed Bloq Description", false, false, null, null, null, "Admin Seed Bloq Title" },
                    { new Guid("db2f6fa6-664e-4381-880b-88a7b0563440"), new Guid("9ec5bf5a-8215-453b-ae4c-55ea4b337823"), "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 615, DateTimeKind.Utc).AddTicks(3936), null, null, "Daniel Seed Bloq Description", false, false, null, null, null, "Daniel Seed Bloq Title" }
                });

            migrationBuilder.InsertData(
                table: "Posts",
                columns: new[] { "Id", "ApplicationUserId", "BloqId", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "Description", "IsPublished", "ModifiedBy", "ModifiedOn", "Published", "Title" },
                values: new object[,]
                {
                    { new Guid("1ef5202a-3982-4bd3-9e02-8e544717aa58"), new Guid("cbeca2b2-01d7-4014-aea3-f7c8a809a905"), new Guid("954c3a03-9992-452a-8c22-f306d7ecbfcd"), "Admin Seed Bloq Post 2/2 Content", "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 577, DateTimeKind.Utc).AddTicks(9700), null, null, "Admin Seed Bloq Post 2/2 Description", true, null, null, null, "Admin Seed Bloq Post 2/2" },
                    { new Guid("22ec441d-2c36-4979-a85e-9d686e9606ec"), new Guid("cbeca2b2-01d7-4014-aea3-f7c8a809a905"), new Guid("954c3a03-9992-452a-8c22-f306d7ecbfcd"), "Admin Seed Bloq Post 1/2 Content", "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 577, DateTimeKind.Utc).AddTicks(9698), null, null, "Admin Seed Bloq Post 1/2 Description", true, null, null, null, "Admin Seed Bloq Post 1/2" },
                    { new Guid("fe39ae01-336c-4938-a9ef-d3ddfdfd0361"), new Guid("9ec5bf5a-8215-453b-ae4c-55ea4b337823"), new Guid("db2f6fa6-664e-4381-880b-88a7b0563440"), "Daniel Seed Bloq Post 1/1 Content", "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 615, DateTimeKind.Utc).AddTicks(3951), null, null, "Daniel Seed Bloq Post 1/1 Description", true, null, null, null, "Daniel Seed Bloq Post 1/1" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "ApplicationUserId", "Content", "CreatedBy", "CreatedOn", "DeletedBy", "DeletedOn", "IsPublished", "ModifiedBy", "ModifiedOn", "PostId", "Published" },
                values: new object[,]
                {
                    { new Guid("15b8e778-83a3-435f-a177-752d507c30c9"), new Guid("cbeca2b2-01d7-4014-aea3-f7c8a809a905"), "Admin Seed Bloq Post 1 Comment 2/2", "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 577, DateTimeKind.Utc).AddTicks(9706), null, null, true, null, null, new Guid("22ec441d-2c36-4979-a85e-9d686e9606ec"), null },
                    { new Guid("4ed8541c-311d-402a-9286-9e30a12693f8"), new Guid("9ec5bf5a-8215-453b-ae4c-55ea4b337823"), "Daniel Seed Bloq Post Comment 3/3", "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 615, DateTimeKind.Utc).AddTicks(3959), null, null, true, null, null, new Guid("fe39ae01-336c-4938-a9ef-d3ddfdfd0361"), null },
                    { new Guid("5458a84b-0762-4550-a6af-0e2e518c1d53"), new Guid("cbeca2b2-01d7-4014-aea3-f7c8a809a905"), "Admin Seed Bloq Post 1 Comment 1/2", "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 577, DateTimeKind.Utc).AddTicks(9704), null, null, true, null, null, new Guid("22ec441d-2c36-4979-a85e-9d686e9606ec"), null },
                    { new Guid("9834727c-9134-4148-b7b1-8e2a6d3a0bde"), new Guid("9ec5bf5a-8215-453b-ae4c-55ea4b337823"), "Daniel Seed Bloq Post Comment 2/3", "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 615, DateTimeKind.Utc).AddTicks(3958), null, null, true, null, null, new Guid("fe39ae01-336c-4938-a9ef-d3ddfdfd0361"), null },
                    { new Guid("a1a0fc2a-8c93-4615-9773-a54435932eab"), new Guid("9ec5bf5a-8215-453b-ae4c-55ea4b337823"), "Daniel Seed Bloq Post Comment 1/3", "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 615, DateTimeKind.Utc).AddTicks(3956), null, null, true, null, null, new Guid("fe39ae01-336c-4938-a9ef-d3ddfdfd0361"), null },
                    { new Guid("d36369b7-8bf8-4e2e-b7ca-9ff650cc852f"), new Guid("cbeca2b2-01d7-4014-aea3-f7c8a809a905"), "Admin Seed Bloq Post 2 Comment 1/1", "Seed", new DateTime(2024, 7, 22, 13, 38, 11, 577, DateTimeKind.Utc).AddTicks(9707), null, null, true, null, null, new Guid("1ef5202a-3982-4bd3-9e02-8e544717aa58"), null }
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
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Bloqs_ApplicationUserId",
                table: "Bloqs",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_ApplicationUserId",
                table: "Comments",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_PostId",
                table: "Comments",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_ApplicationUserId",
                table: "Posts",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_BloqId",
                table: "Posts",
                column: "BloqId");
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
                name: "Comments");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Bloqs");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
