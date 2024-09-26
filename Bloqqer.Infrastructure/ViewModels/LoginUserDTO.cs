namespace Bloqqer.Infrastructure.ViewModels;

public sealed record LoginUserDTO(
    string Email,
    string Password,
    bool RememberMe
);