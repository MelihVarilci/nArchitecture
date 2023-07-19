using Core.Security.Moldels;

namespace Core.Security.JWT;

public interface ITokenHelper
{
    public int RefreshTokenTTLOption { get; }

    AccessToken CreateToken(AppUser user, ICollection<AppUserClaim> operationClaims);

    AppUserToken CreateRefreshToken(AppUser user, string ipAddress);
}