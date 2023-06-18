using FluentValidation;

namespace Application.Features.ProgrammingLanguages.Commands.CreateOrEditProgrammingLanguage
{
    public class CreateOrEditProgrammingLanguageCommandValidator : AbstractValidator<CreateOrEditProgrammingLanguageCommand>
    {
        public CreateOrEditProgrammingLanguageCommandValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
        }
    }
}