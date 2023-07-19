using Core.Persistence.Repositories;
using Core.Security.Moldels;

namespace Application.Services.Repositories
{
    public interface IAppUserClaimRepository : IAsyncRepository<AppUserClaim>, IRepository<AppUserClaim>
    {
        public Task<ICollection<AppUserClaim>> GetOperationClaimsByUserIdAsync(int userId);
    }
}