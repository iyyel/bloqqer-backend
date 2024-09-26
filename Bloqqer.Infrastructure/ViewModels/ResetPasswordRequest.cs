namespace Bloqqer.Infrastructure.ViewModels;

public sealed record ResetPasswordRequest(
    string Email,
    string FirstName,
    string MiddleName,
    string LastName,
    string ResetPasswordToken
);