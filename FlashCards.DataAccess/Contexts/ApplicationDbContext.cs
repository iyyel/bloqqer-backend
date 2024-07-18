using FlashCards.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.DataAccess.Contexts;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<FlashCard> FlashCards { get; set; }
    public DbSet<FlashCardSet> FlashCardSets { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var flashCardsOne = new List<FlashCard>()
        {
            new() {
                Id = Guid.NewGuid(),
                Front = "Front 1 1",
                Back = "Back 1 1"
            },
            new() {
                Id = Guid.NewGuid(),
                Front = "Front 1 2",
                Back = "Back 1 2"
            },
            new() {
                Id = Guid.NewGuid(),
                Front = "Front 1 3",
                Back = "Back 1 3"
            }
        };

        var flashCardsTwo = new List<FlashCard>()
        {
           new() {
                Id = Guid.NewGuid(),
                Front = "Front 2 1",
                Back = "Back 2 1"
            },
            new() {
                Id = Guid.NewGuid(),
                Front = "Front 2 2",
                Back = "Back 2 2"
            }
        };

        var flashCardSetOne = new FlashCardSet()
        {
            Id = Guid.NewGuid(),
            SetName = "Set 1",
            FlashCards = flashCardsOne,
        };

        var flashCardSetTwo = new FlashCardSet()
        {
            Id = Guid.NewGuid(),
            SetName = "Set 2",
            FlashCards = flashCardsTwo,
        };

        modelBuilder.Entity<FlashCard>().HasData(flashCardsOne, flashCardsTwo);
        modelBuilder.Entity<FlashCardSet>().HasData(flashCardsOne, flashCardSetTwo);
    }

}