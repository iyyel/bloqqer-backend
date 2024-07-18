using FlashCards.DataAccess.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FlashCards.DataAccess.Contexts;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
{
    public DbSet<FlashCard> FlashCards { get; set; }
    public DbSet<FlashCardSet> FlashCardSets { get; set; }
}