using Application.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException(Messages.OperationClaimNameExist);
        }

        public void OperationClaimShouldExistWhenRequested(OperationClaim? operationClaim)
        {
            if (operationClaim is null) throw new BusinessException(Messages.OperationClaimNotFound);
        }
    }
}