using FluentValidation;

namespace Application.Features.Authentications.Commands.Register
{
    public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RegisterCommandValidator()
        {
            RuleFor(x => x.UserForRegisterDto.FirstName).NotEmpty();
            RuleFor(x => x.UserForRegisterDto.LastName).NotEmpty();
            RuleFor(x => x.UserForRegisterDto.Email).EmailAddress();
            RuleFor(x => x.UserForRegisterDto.Password).NotEmpty().MinimumLength(6);
        }
    }
}