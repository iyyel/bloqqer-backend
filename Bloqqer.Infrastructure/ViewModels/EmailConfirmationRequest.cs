namespace Bloqqer.Infrastructure.ViewModels;

public class EmailConfirmationRequest
{
    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string MiddleName { get; set; }

    public required string LastName { get; set; }

    public required string ConfirmationToken { get; set; }
}