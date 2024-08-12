namespace Bloqqer.WebAPI.Services.Interfaces;

public interface ISecretService
{
    string GetSecret(string secretName);
}