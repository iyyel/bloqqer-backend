using Bloqqer.WebAPI.Services.Interfaces;
using SendGrid.Helpers.Mail;
using SendGrid;
using System.Web;
using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services;

public sealed class EmailService(ISecretService _secretService) : IEmailService
{
    private readonly ISecretService _secretService = _secretService;

    public async Task<bool> SendEmailConfirmationRequest(EmailConfirmationRequest emailConfirmationRequest)
    {
        var client = new SendGridClient(_secretService.GetSecret("SendGrid-APIKey"));
        var emailConfirmationLink = $"{_secretService.GetSecret("SendGrid-EmailConfirmationAcceptanceAPIUrl")}?email={emailConfirmationRequest.Email}&confirmEmailToken={HttpUtility.UrlEncode(emailConfirmationRequest.ConfirmationToken)}";

        var message = new SendGridMessage()
        {
            From = new EmailAddress(_secretService.GetSecret("SendGrid-FromEmailAddress"), "Bloqqer"),
            TemplateId = _secretService.GetSecret("SendGrid-EmailConfirmationRequestTemplateId"),
        };

        message.SetTemplateData(new
        {
            emailConfirmationLink
        });

        message.AddTo(new EmailAddress(emailConfirmationRequest.Email, $"{emailConfirmationRequest.FirstName} {emailConfirmationRequest.MiddleName} {emailConfirmationRequest.LastName}"));
        message.SetClickTracking(false, false);

        var response = await client.SendEmailAsync(message);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> SendEmailConfirmationAcceptance(EmailConfirmationAcceptance emailConfirmationAcceptance)
    {
        var client = new SendGridClient(_secretService.GetSecret("SendGrid-APIKey"));

        var message = new SendGridMessage()
        {
            From = new EmailAddress(_secretService.GetSecret("SendGrid-FromEmailAddress"), "Bloqqer"),
            TemplateId = _secretService.GetSecret("SendGrid-EmailConfirmationAcceptanceTemplateId"),
        };

        message.AddTo(new EmailAddress(emailConfirmationAcceptance.Email, $"{emailConfirmationAcceptance.FirstName} {emailConfirmationAcceptance.MiddleName} {emailConfirmationAcceptance.LastName}"));
        message.SetClickTracking(false, false);

        var response = await client.SendEmailAsync(message);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> SendResetPasswordRequest(ResetPasswordRequest resetPasswordRequest)
    {
        var client = new SendGridClient(_secretService.GetSecret("SendGrid-APIKey"));
        var resetPasswordLink = $"{_secretService.GetSecret("SendGrid-ResetPasswordRequestAPIUrl")}?email={resetPasswordRequest.Email}&resetPasswordToken={HttpUtility.UrlEncode(resetPasswordRequest.ResetPasswordToken)}";

        var message = new SendGridMessage()
        {
            From = new EmailAddress(_secretService.GetSecret("SendGrid-FromEmailAddress"), "Bloqqer"),
            TemplateId = _secretService.GetSecret("SendGrid-ResetPasswordRequestTemplateId"),
        };
        message.SetTemplateData(new
        {
            resetPasswordLink
        });

        message.AddTo(new EmailAddress(resetPasswordRequest.Email, $"{resetPasswordRequest.FirstName} {resetPasswordRequest.MiddleName} {resetPasswordRequest.LastName}"));
        message.SetClickTracking(false, false);

        var response = await client.SendEmailAsync(message);
        return response.IsSuccessStatusCode;
    }

    public async Task<bool> SendResetPasswordAcceptance(ResetPasswordAcceptance resetPasswordAcceptance)
    {
        var client = new SendGridClient(_secretService.GetSecret("SendGrid-APIKey"));

        var message = new SendGridMessage()
        {
            From = new EmailAddress(_secretService.GetSecret("SendGrid-FromEmailAddress"), "Bloqqer"),
            TemplateId = _secretService.GetSecret("SendGrid-PasswordResetAcceptanceTemplateId"),
        };

        message.AddTo(new EmailAddress(resetPasswordAcceptance.Email, $"{resetPasswordAcceptance.FirstName} {resetPasswordAcceptance.MiddleName} {resetPasswordAcceptance.LastName}"));
        message.SetClickTracking(false, false);

        var response = await client.SendEmailAsync(message);
        return response.IsSuccessStatusCode;
    }
}