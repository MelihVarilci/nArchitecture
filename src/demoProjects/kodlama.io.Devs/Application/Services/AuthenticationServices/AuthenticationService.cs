using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Mailing;
using Core.Security.EmailAuthenticator;
using Core.Security.Entities;
using Core.Security.Enums;
using Core.Security.JWT;
using Core.Security.OtpAuthenticator;

namespace Application.Services.AuthenticationServices
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly IEmailAuthenticatorHelper _emailAuthenticatorHelper;
        private readonly IEmailAuthenticatorRepository _emailAuthenticatorRepository;
        private readonly IMailService _mailService;
        private readonly IOtpAuthenticatorHelper _otpAuthenticatorHelper;
        private readonly IOtpAuthenticatorRepository _otpAuthenticatorRepository;

        public AuthenticationService(IUserOperationClaimRepository userOperationClaimRepository,
            ITokenHelper tokenHelper, IRefreshTokenRepository refreshTokenRepository,
            IEmailAuthenticatorHelper emailAuthenticatorHelper,
            IEmailAuthenticatorRepository emailAuthenticatorRepository,
            IMailService mailService,
            IOtpAuthenticatorHelper otpAuthenticatorHelper,
            IOtpAuthenticatorRepository otpAuthenticatorRepository)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _tokenHelper = tokenHelper;
            _refreshTokenRepository = refreshTokenRepository;
            _emailAuthenticatorHelper = emailAuthenticatorHelper;
            _emailAuthenticatorRepository = emailAuthenticatorRepository;
            _mailService = mailService;
            _otpAuthenticatorHelper = otpAuthenticatorHelper;
            _otpAuthenticatorRepository = otpAuthenticatorRepository;
        }

        public async Task<RefreshToken> AddRefreshToken(RefreshToken refreshToken)
        {
            RefreshToken addedRefreshToken = await _refreshTokenRepository.AddAsync(refreshToken);
            return addedRefreshToken;
        }

        public async Task<AccessToken> CreateAccessToken(User user)
        {
            ICollection<OperationClaim> operationClaims =
                await _userOperationClaimRepository.GetOperationClaimsByUserIdAsync(user.Id);
            AccessToken accessToken = _tokenHelper.CreateToken(user, operationClaims);
            return accessToken;
        }

        public Task<RefreshToken> CreateRefreshToken(User user, string ipAddress)
        {
            RefreshToken refreshToken = _tokenHelper.CreateRefreshToken(user, ipAddress);
            return Task.FromResult(refreshToken);
        }

        public async Task DeleteOldActiveRefreshTokens(User user)
        {
            // Yeni login işleminde, yeni bir refresh token zinciri oluşacaktır. Hali hazırda bulunan diğer zincirler (en son aktif olan token'a göre) yeterince eskiyse (RefreshTokenTTL opsiyonundaki süre kadar) silinir.
            ICollection<RefreshToken> oldActiveRefreshTokens = await _refreshTokenRepository
                                                                   .GetAllOldActiveRefreshTokensAsync(
                                                                       user, _tokenHelper.RefreshTokenTTLOption);
            await _refreshTokenRepository.DeleteRangeAsync(oldActiveRefreshTokens.ToList());
        }

        public async Task SendAuthenticatorCode(User user)
        {
            switch (user.AuthenticatorType)
            {
                case AuthenticatorType.Email:
                    await sendAuthenticatorCodeWithEmail(user);
                    break;
            }
        }

        public async Task VerifyAuthenticatorCode(User user, string code)
        {
            switch (user.AuthenticatorType)
            {
                case AuthenticatorType.Email:
                    await verifyEmailAuthenticatorCode(user, code);
                    break;

                case AuthenticatorType.Otp:
                    await verifyOtpAuthenticatorCode(user, code);
                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private async Task sendAuthenticatorCodeWithEmail(User user)
        {
            EmailAuthenticator userEmailAuthenticator =
                await _emailAuthenticatorRepository.GetAsync(uea => uea.UserId == user.Id);

            string authenticatorCode = await _emailAuthenticatorHelper.CreateEmailAuthenticatorCodeAsync();
            userEmailAuthenticator.ActivationKey = authenticatorCode;
            await _emailAuthenticatorRepository.UpdateAsync(userEmailAuthenticator);

            Mail mailData = new()
            {
                ToFullName = $"{user.FirstName} {user.LastName}",
                ToEmail = user.Email,
                Subject = AuthenticationServiceBusinessMessages.AuthenticatorCodeSubject,
                TextBody = AuthenticationServiceBusinessMessages.AuthenticatorCodeTextBody(authenticatorCode)
            };
            await _mailService.SendMailAsync(mailData);
        }

        private async Task verifyEmailAuthenticatorCode(User user, string code)
        {
            EmailAuthenticator userEmailAuthenticator =
                await _emailAuthenticatorRepository.GetAsync(uea => uea.UserId == user.Id);

            if (userEmailAuthenticator.ActivationKey != code)
                throw new BusinessException(AuthenticationServiceBusinessMessages.InvalidAuthenticatorCode);

            userEmailAuthenticator.ActivationKey = null;
            await _emailAuthenticatorRepository.UpdateAsync(userEmailAuthenticator);
        }

        private async Task verifyOtpAuthenticatorCode(User user, string codeToVerify)
        {
            OtpAuthenticator userOtpAuthenticator =
                await _otpAuthenticatorRepository.GetAsync(uoa => uoa.UserId == user.Id);

            bool result = await _otpAuthenticatorHelper.VerifyCodeAsync(userOtpAuthenticator.SecretKey, codeToVerify);

            if (!result)
                throw new BusinessException(AuthenticationServiceBusinessMessages.InvalidAuthenticatorCode);
        }
    }
}