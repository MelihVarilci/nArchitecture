using Application.Features.Authentications.Dtos;
using Application.Features.Authentications.Rules;
using Application.Services.AuthenticationServices;
using Application.Services.Repositories;
using Core.Security.Dtos;
using Core.Security.Enums;
using Core.Security.JWT;
using Core.Security.Moldels;
using MediatR;

namespace Application.Features.Authentications.Commands.Login
{
    public class LoginCommand : IRequest<LoggedResponse>
    {
        public UserForLoginDto UserForLoginDto { get; set; }
        public string IpAddress { get; set; }

        public class LoginCommandHandler : IRequestHandler<LoginCommand, LoggedResponse>
        {
            private readonly IUserRepository _userRepository;
            private readonly IAuthenticationService _authenticationService;
            private readonly AuthenticationBusinessRules _authenticationBusinessRules;

            public LoginCommandHandler(IUserRepository userRepository,
                IAuthenticationService authenticationService,
                AuthenticationBusinessRules authenticationBusinessRules)
            {
                _userRepository = userRepository;
                _authenticationService = authenticationService;
                _authenticationBusinessRules = authenticationBusinessRules;
            }

            public async Task<LoggedResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
            {
                AppUser? user = await _userRepository.GetAsync(u => u.Email == request.UserForLoginDto.Email);
                await _authenticationBusinessRules.UserShouldBeExists(user);
                await _authenticationBusinessRules.UserPasswordShouldBeMatch(user: user!, request.UserForLoginDto.Password);

                LoggedResponse response = new();
                if (user!.AuthenticatorType is not AuthenticatorType.None)
                {
                    if (request.UserForLoginDto.AuthenticatorCode is null)
                    {
                        await _authenticationService.SendAuthenticatorCode(user);
                        response.RequiredAuthenticatorType = user.AuthenticatorType;
                        return response;
                    }
                    else
                    {
                        await _authenticationService.VerifyAuthenticatorCode(user, request.UserForLoginDto.AuthenticatorCode);
                    }
                }

                AccessToken createdAccessToken = await _authenticationService.CreateAccessToken(user!);

                await _authenticationService.DeleteOldActiveRefreshTokens(user!);
                AppUserToken refreshToken = await _authenticationService.CreateRefreshToken(user: user!, request.IpAddress);
                await _authenticationService.AddRefreshToken(refreshToken);

                response.AccessToken = createdAccessToken;
                response.RefreshToken = refreshToken;
                return response;
            }
        }
    }
}