namespace Bloqqer.Infrastructure.ViewModels;

public sealed record EmailConfirmationRequest(
    string Email,
    string FirstName,
    string MiddleName,
    string LastName,
    string ConfirmationToken
);