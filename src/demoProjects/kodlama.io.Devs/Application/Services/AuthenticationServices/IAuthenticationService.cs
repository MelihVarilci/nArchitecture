using Core.Security.JWT;
using Core.Security.Moldels;

namespace Application.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        public Task<AppUserToken> AddRefreshToken(AppUserToken refreshToken);

        public Task<AccessToken> CreateAccessToken(AppUser user);

        public Task<AppUserToken> CreateRefreshToken(AppUser user, string ipAddress);

        public Task DeleteOldActiveRefreshTokens(AppUser user); // Login olunduğunda eski aktif refresh token'ları (TTL süresiyle birlikte) siler

        public Task SendAuthenticatorCode(AppUser user);

        public Task VerifyAuthenticatorCode(AppUser user, string code);
    }
}