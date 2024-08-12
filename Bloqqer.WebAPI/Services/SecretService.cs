using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Bloqqer.WebAPI.Services.Interfaces;

namespace Bloqqer.WebAPI.Services;

// TODO: Research whether this is the best way to handle secrets.
public sealed class SecretService : ISecretService
{
    private readonly SecretClient _secretClient;

    public SecretService(IConfiguration config)
    {
        SecretClientOptions options = new()
        {
            Retry =
            {
                Delay= TimeSpan.FromSeconds(2),
                MaxDelay = TimeSpan.FromSeconds(16),
                MaxRetries = 5,
                Mode = RetryMode.Exponential
            }
        };
        _secretClient = new SecretClient(new Uri(config["KeyVaults:BloqqerUrl"]), new DefaultAzureCredential(), options);
    }

    public string GetSecret(string secretName)
    {
        var secret = _secretClient.GetSecret(secretName);
        return secret.Value.Value;
    }
}