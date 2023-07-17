using Core.Persistence.Repositories;
using Core.Security.Moldels;

namespace Application.Services.Repositories
{
    public interface IUserOperationClaimRepository : IAsyncRepository<UserOperationClaim>, IRepository<UserOperationClaim>
    {
        public Task<ICollection<OperationClaim>> GetOperationClaimsByUserIdAsync(int userId);
    }
}