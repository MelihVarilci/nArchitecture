using Core.Security.Entities;

namespace Core.Security.JWT;

public interface ITokenHelper
{
    public int RefreshTokenTTLOption { get; }

    AccessToken CreateToken(User user, ICollection<OperationClaim> operationClaims);

    RefreshToken CreateRefreshToken(User user, string ipAddress);
}