using Core.Security.Enums;
using Core.Security.JWT;
using Core.Security.Moldels;

namespace Application.Features.Authentications.Dtos
{
    public class LoggedResponse
    {
        public AccessToken? AccessToken { get; set; }
        public AppUserToken? RefreshToken { get; set; }
        public AuthenticatorType? RequiredAuthenticatorType { get; set; }

        public class LoggedHttpResponse
        {
            public AccessToken? AccessToken { get; set; }
            public AuthenticatorType? RequiredAuthenticatorType { get; set; }
        }

        public LoggedHttpResponse ToHttpResponse()
            => new()
            {
                AccessToken = AccessToken,
                RequiredAuthenticatorType = RequiredAuthenticatorType
            };
    }
}