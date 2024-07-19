using Microsoft.AspNetCore.Identity;

namespace FlashCards.DataAccess.Entities;

public class ApplicationUser : IdentityUser
{
    public virtual ICollection<FlashCardSet>? FlashCardSets { get; set; }
}