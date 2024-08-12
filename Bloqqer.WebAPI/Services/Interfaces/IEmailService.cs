using Bloqqer.Infrastructure.ViewModels;

namespace Bloqqer.WebAPI.Services.Interfaces;

public interface IEmailService
{
    Task<bool> SendEmailConfirmationRequest(EmailConfirmationRequest emailConfirmationRequest);

    Task<bool> SendEmailConfirmationAcceptance(EmailConfirmationAcceptance emailConfirmationAcceptance);

    Task<bool> SendResetPasswordRequest(ResetPasswordRequest resetPasswordRequest);

    Task<bool> SendResetPasswordAcceptance(ResetPasswordAcceptance resetPasswordAcceptance);
}