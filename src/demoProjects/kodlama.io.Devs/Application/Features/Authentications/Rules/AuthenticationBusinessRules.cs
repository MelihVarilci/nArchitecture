using Application.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Enums;
using Core.Security.Hashing;
using Core.Security.Moldels;

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
            AppUser? user = await _userRepository.GetAsync(u => u.Email.Equals(email.ToLower()));
            if (user is not null) throw new BusinessException(Messages.UserEmailAlreadyExists);
        }

        public Task UserShouldBeExists(AppUser? user)
        {
            if (user == null)
                throw new BusinessException(Messages.UserNotFound);
            return Task.CompletedTask;
        }

        public Task UserPasswordShouldBeMatch(AppUser user, string password)
        {
            bool isMatched = HashingHelper.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt);
            if (isMatched == false)
                throw new BusinessException(Messages.UserPasswordNotMatch);
            return Task.CompletedTask;
        }

        public Task RefreshTokenShouldBeExists(AppUserToken? refreshToken)
        {
            if (refreshToken == null)
                throw new BusinessException(Messages.RefreshTokenNotFound);
            return Task.CompletedTask;
        }

        public Task RefreshTokenShouldBeActive(AppUserToken refreshToken)
        {
            if (refreshToken.Revoked != null ||
                (refreshToken.Revoked == null && refreshToken.Expires < DateTime.UtcNow))
                throw new BusinessException(Messages.RefreshTokenNotActive);
            return Task.CompletedTask;
        }

        public Task UserShouldNotBeHasAuthenticator(AppUser user)
        {
            if (user.AuthenticatorType is not AuthenticatorType.None)
                throw new BusinessException(Messages.UserAlreadyHasAuthenticator);
            return Task.CompletedTask;
        }

        public Task UserEmailAuthenticatorShouldBeExists(EmailAuthenticator? userEmailAuthenticator)
        {
            if (userEmailAuthenticator is null)
                throw new BusinessException(Messages.UserEmailAuthenticatorNotFound);
            return Task.CompletedTask;
        }

        public Task UserOtpAuthenticatorShouldBeExists(OtpAuthenticator userOtpAuthenticator)
        {
            if (userOtpAuthenticator is null)
                throw new BusinessException(Messages.UserOtpAuthenticatorNotFound);
            return Task.CompletedTask;
        }
    }
}