namespace Bloqqer.Infrastructure.ViewModels;

public sealed record ResetPasswordAcceptance(
    string Email,
    string FirstName,
    string MiddleName,
    string LastName
);