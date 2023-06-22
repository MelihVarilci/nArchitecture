using FluentValidation;

namespace Application.Features.Technologies.Commands.CreateOrEditTechnology
{
    public class CreateOrEditTechnologyCommandValidator : AbstractValidator<CreateOrEditTechnologyCommand>
    {
        public CreateOrEditTechnologyCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}