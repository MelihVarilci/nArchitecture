using Core.Persistence.Repositories;
using Core.Security.Moldels;

namespace Application.Services.Repositories
{
    public interface IOperationClaimRepository : IAsyncRepository<OperationClaim>, IRepository<OperationClaim>
    {
    }
}