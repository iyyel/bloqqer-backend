using FlashCards.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.DataAccess.Contexts;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>(options)
{
    public DbSet<FlashCard> FlashCards { get; set; }
    public DbSet<FlashCardSet> FlashCardSets { get; set; }
    new public DbSet<ApplicationRole> Roles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        new DbInitializer(modelBuilder).Seed();
    }
}