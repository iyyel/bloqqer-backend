namespace Bloqqer.Infrastructure.ViewModels;

public class LoginUserDTO
{
    public required string Email { get; set; }

    public required string Password { get; set; }

    public required bool RememberMe { get; set; }
}