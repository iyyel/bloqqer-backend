namespace Bloqqer.Infrastructure.ViewModels;

public sealed record LoginUserDTO(
    string UserName,
    string Password,
    bool RememberMe
);