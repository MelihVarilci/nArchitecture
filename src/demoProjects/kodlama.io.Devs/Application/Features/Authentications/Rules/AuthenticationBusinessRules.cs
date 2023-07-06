using Application.Features.Authentications.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.Hashing;

namespace Application.Features.Authentications.Rules
{
    public class AuthenticationBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task UserEmailCannotBeDuplicatedWhenInserted(string email)
        {
            User? user = await _userRepository.GetAsync(u => u.Email.Equals(email.ToLower()));
            if (user is not null) throw new BusinessException(AuthenticationBusinessMessages.UserEmailAlreadyExists);
        }

        public Task UserShouldBeExists(User? user)
        {
            if (user == null)
                throw new BusinessException(AuthenticationBusinessMessages.UserNotFound);
            return Task.CompletedTask;
        }

        public Task UserPasswordShouldBeMatch(User user, string password)
        {
            bool isMatched = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (isMatched == false)
                throw new BusinessException(AuthenticationBusinessMessages.UserPasswordNotMatch);
            return Task.CompletedTask;
        }

        public Task RefreshTokenShouldBeExists(RefreshToken? refreshToken)
        {
            if (refreshToken == null)
                throw new BusinessException(AuthenticationBusinessMessages.RefreshTokenNotFound);
            return Task.CompletedTask;
        }

        public Task RefreshTokenShouldBeActive(RefreshToken refreshToken)
        {
            if (refreshToken.Revoked != null ||
                (refreshToken.Revoked == null && refreshToken.Expires < DateTime.UtcNow))
                throw new BusinessException(AuthenticationBusinessMessages.RefreshTokenNotActive);
            return Task.CompletedTask;
        }

        public Task UserShouldNotBeHasAuthenticator(User user)
        {
            if (user.AuthenticatorType is not AuthenticatorType.None)
                throw new BusinessException(AuthenticationBusinessMessages.UserAlreadyHasAuthenticator);
            return Task.CompletedTask;
        }

        public Task UserEmailAuthenticatorShouldBeExists(EmailAuthenticator? userEmailAuthenticator)
        {
            if (userEmailAuthenticator is null)
                throw new BusinessException(AuthenticationBusinessMessages.UserEmailAuthenticatorNotFound);
            return Task.CompletedTask;
        }

        public Task UserOtpAuthenticatorShouldBeExists(OtpAuthenticator userOtpAuthenticator)
        {
            if (userOtpAuthenticator is null)
                throw new BusinessException(AuthenticationBusinessMessages.UserOtpAuthenticatorNotFound);
            return Task.CompletedTask;
        }
    }
}