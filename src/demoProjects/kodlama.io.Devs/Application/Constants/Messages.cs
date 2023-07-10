namespace Application.Constants
{
    public static class Messages
    {
        public const string UserNotFound = "Kullanıcı bulunamadı.";
        public const string UserProfileNotFound = "Kullanıcı Profili bulunamadı.";
        public const string UserPasswordNotMatch = "Kullanıcı şifresi eşleşmiyor.";
        public const string UserEmailAlreadyExists = "Bu e-posta adresi ile daha önce kayıt olunmuş.";
        public const string UserOperationClaimNotFound = "Kullanıcı Operasyon Talebi bulunamadı.";
        public const string UserAlreadyHasAuthenticator = "Kullanıcı zaten bir doğrulayıcıya sahip.";
        public const string UserOtpAuthenticatorNotFound = "Kullanıcıya ait onaylanması gereken OTP doğrulama isteği bulunamadı.";
        public const string UserEmailAuthenticatorNotFound = "Kullanıcıya ait onaylanması gereken e-posta doğrulama isteği bulunamadı.";

        public const string VerifyEmail = "E-posta adresinizi doğrulayın!";

        public const string ClickOnBelowLinkToVerifyEmail = "E-posta adresinizi doğrulamak için lütfen aşağıdaki linke tıklayın:";

        public const string RefreshTokenNotFound = "Refresh token bulunamadı.";
        public const string RefreshTokenNotActive = "Refresh token aktif değil.";

        public const string OperationClaimNotFound = "Operasyon Talebi bulunamadı.";
        public const string OperationClaimNameExist = "Operasyon Talebi ismi zaten mevcut.";

        public static string UserEmailAlreadyExitsByEmail(string email)
        {
            return $"{email} e-posta adresiyle ile daha önce kayıt olunmuş.";
        }
    }
}