using Core.Security.JWT;
using Core.Security.Moldels;

namespace Application.Features.Authentications.Dtos
{
    public class RegisteredResponse
    {
        public AccessToken AccessToken { get; set; }
        public AppUserToken RefreshToken { get; set; }
    }
}