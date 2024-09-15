namespace Bloqqer.Infrastructure.ViewModels;

public class RegisterUserDTO
{
    public required string FirstName { get; set; }

    public required string MiddleName { get; set; }

    public required string LastName { get; set; }

    public required string UserName { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public required string Password { get; set; }
}