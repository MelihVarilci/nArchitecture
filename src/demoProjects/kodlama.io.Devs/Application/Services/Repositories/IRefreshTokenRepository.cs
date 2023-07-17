using Core.Persistence.Repositories;
using Core.Security.Moldels;

namespace Application.Services.Repositories
{
    public interface IRefreshTokenRepository : IAsyncRepository<AppUserToken>, IRepository<AppUserToken>
    {
        public Task<ICollection<AppUserToken>> GetAllOldActiveRefreshTokensAsync(AppUser user, int ttl);
    }
}