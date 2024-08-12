namespace Bloqqer.Infrastructure.ViewModels;

public class ResetPasswordRequest
{
    public required string Email { get; set; }

    public required string FirstName { get; set; }

    public required string MiddleName { get; set; }

    public required string LastName { get; set; }

    public required string ResetPasswordToken { get; set; }
}