namespace Bloqqer.Infrastructure.ViewModels;

public sealed record RegisterUserDTO(
    string FirstName,
    string MiddleName,
    string LastName,
    string UserName,
    string Email,
    string PhoneNumber,
    string Password
);