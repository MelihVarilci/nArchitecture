using FluentValidation;

namespace Application.Features.OperationClaims.Commands.CreateOrEditOperationClaim
{
    public class CreateOrEditOperationClaimCommandValidator : AbstractValidator<CreateOrEditOperationClaimCommand>
    {
        public CreateOrEditOperationClaimCommandValidator()
        {
            RuleFor(c => c.ClaimValue).NotEmpty();
        }
    }
}