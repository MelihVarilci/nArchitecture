using Application.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Security.Entities;

namespace Application.Features.UserOperationClaims.Rules
{
    public class UserOperationClaimBusinessRules : BaseBusinessRules
    {
        private readonly IUserRepository _userRepository;
        private readonly IOperationClaimRepository _operationClaimRepository;

        public UserOperationClaimBusinessRules(IUserRepository userRepository, IOperationClaimRepository operationClaimRepository)
        {
            _userRepository = userRepository;
            _operationClaimRepository = operationClaimRepository;
        }

        public void UserOperationClaimShouldExistWhenRequested(UserOperationClaim? userOperationClaim)
        {
            if (userOperationClaim == null) throw new BusinessException("Requested UserOperationClaim does not exist");
        }

        public async Task UserShouldBeExist(int userId)
        {
            User? user = await _userRepository.GetAsync(x => x.Id == userId);

            if (user is null)
                throw new BusinessException(Messages.UserNotFound);
        }

        public async Task OperationClaimShouldBeExist(int operationClaimId)
        {
            OperationClaim? operationClaim = await _operationClaimRepository.GetAsync(x => x.Id == operationClaimId);

            if (operationClaim is null)
                throw new BusinessException(Messages.UserOperationClaimNotFound);
        }
    }
}