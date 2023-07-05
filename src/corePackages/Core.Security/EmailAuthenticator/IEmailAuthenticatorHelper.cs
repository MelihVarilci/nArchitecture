namespace Core.Security.EmailAuthenticator;

public interface IEmailAuthenticatorHelper
{
    public Task<string> CreateEmailActivationKeyAsync();
    public Task<string> CreateEmailAuthenticatorCodeAsync();
}