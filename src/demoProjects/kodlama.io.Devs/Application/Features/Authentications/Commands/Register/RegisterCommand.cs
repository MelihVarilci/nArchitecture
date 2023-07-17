using Application.Features.Authentications.Dtos;
using Application.Features.Authentications.Rules;
using Application.Services.AuthenticationServices;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.Security.Moldels;
using Domain.Entities;
using MediatR;

namespace Application.Features.Authentications.Commands.Register
{
    public class RegisterCommand : IRequest<RegisteredResponse>
    {
        public UserForRegisterDto UserForRegisterDto { get; set; }
        public string IpAddress { get; set; }

        public class RegisterCommandHandler : IRequestHandler<RegisterCommand, RegisteredResponse>
        {
            private readonly IMapper _mapper;
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IAuthenticationService _authenticationService;
            private readonly AuthenticationBusinessRules _authenticationBusinessRules;

            public RegisterCommandHandler(IMapper mapper,
                IUserProfileRepository userProfileRepository,
                IAuthenticationService authenticationService,
                AuthenticationBusinessRules authenticationBusinessRules)
            {
                _mapper = mapper;
                _userProfileRepository = userProfileRepository;
                _authenticationService = authenticationService;
                _authenticationBusinessRules = authenticationBusinessRules;
            }

            public async Task<RegisteredResponse> Handle(RegisterCommand request, CancellationToken cancellationToken)
            {
                await _authenticationBusinessRules.UserEmailCannotBeDuplicatedWhenInserted(request.UserForRegisterDto.Email);

                // Hashing
                byte[] passwordHash, passwordSalt;
                HashingHelper.CreatePasswordHash(request.UserForRegisterDto.Password, out passwordHash, out passwordSalt);

                // Insert User
                UserProfile newUser = _mapper.Map<UserProfile>(request.UserForRegisterDto);
                newUser.PasswordHash = passwordHash;
                newUser.PasswordSalt = passwordSalt;

                await _userProfileRepository.AddAsync(newUser);

                // Generate AccessToken
                AccessToken createdAccessToken = await _authenticationService.CreateAccessToken(newUser);

                AppUserToken createdRefreshToken = await _authenticationService.CreateRefreshToken(newUser, request.IpAddress);
                await _authenticationService.AddRefreshToken(createdRefreshToken);

                RegisteredResponse response = new()
                {
                    AccessToken = createdAccessToken,
                    RefreshToken = createdRefreshToken
                };

                return response;
            }
        }
    }
}