using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;

namespace Application.Features.Authentications.Commands.Login
{
    public class LoggedResponse
    {
        public AccessToken? AccessToken { get; set; }
        public RefreshToken? RefreshToken { get; set; }
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