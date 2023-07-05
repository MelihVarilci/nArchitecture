using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Services.AuthenticationServices
{
    public interface IAuthenticationService
    {
        public Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken);

        public Task<AccessToken> CreateAccessToken(User user);

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress);

        public Task DeleteOldActiveRefreshTokens(User user); // Login olunduğunda eski aktif refresh token'ları (TTL süresiyle birlikte) siler

        public Task SendAuthenticatorCode(User user);

        public Task VerifyAuthenticatorCode(User user, string code);
    }
}