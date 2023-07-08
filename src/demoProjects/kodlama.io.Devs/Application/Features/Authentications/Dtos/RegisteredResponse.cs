using Core.Security.Entities;
using Core.Security.JWT;

namespace Application.Features.Authentications.Dtos
{
    public class RegisteredResponse
    {
        public AccessToken AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}