using Application.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Moldels;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IAppUserClaimRepository _appUserClaimRepository;

        public OperationClaimBusinessRules(IAppUserClaimRepository appUserClaimRepository)
        {
            _appUserClaimRepository = appUserClaimRepository;
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string claimValue)
        {
            IPaginate<AppUserClaim> result = await _appUserClaimRepository.GetListAsync(b => b.ClaimValue == claimValue);
            if (result.Items.Any()) throw new BusinessException(Messages.OperationClaimNameExist);
        }

        public void OperationClaimShouldExistWhenRequested(AppUserClaim? userClaim)
        {
            if (userClaim is null) throw new BusinessException(Messages.OperationClaimNotFound);
        }
    }
}