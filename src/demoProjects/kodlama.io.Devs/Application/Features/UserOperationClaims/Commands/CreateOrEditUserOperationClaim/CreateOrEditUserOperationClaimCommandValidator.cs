using Core.Security.Entities;
using FluentValidation;

namespace Application.Features.UserOperationClaims.Commands.CreateOrEditUserOperationClaim
{
    public class CreateOrEditUserOperationClaimCommandValidator : AbstractValidator<UserOperationClaim>
    {
        public CreateOrEditUserOperationClaimCommandValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.OperationClaimId).NotEmpty();
        }
    }
}