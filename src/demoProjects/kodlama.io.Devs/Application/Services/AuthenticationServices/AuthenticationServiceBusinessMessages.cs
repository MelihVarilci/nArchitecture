namespace Application.Services.AuthenticationServices
{
    public class AuthenticationServiceBusinessMessages
    {
        public const string AuthenticatorCodeSubject = "Girişini onaylamak için kodu giriniz - Kodlama.io.Devs";
        public const string InvalidAuthenticatorCode = "İki adımlı doğrulama kodu yanlış.";

        public static string AuthenticatorCodeTextBody(string authenticatorCode)
            => $"İki adımlı doğrulama kodunuz: {authenticatorCode.Substring(startIndex: 0, length: 3)} {authenticatorCode.Substring(3)}";
    }
}