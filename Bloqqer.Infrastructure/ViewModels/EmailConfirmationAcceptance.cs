namespace Bloqqer.Infrastructure.ViewModels;

public sealed record EmailConfirmationAcceptance(
    string Email,
    string FirstName,
    string MiddleName,
    string LastName
);