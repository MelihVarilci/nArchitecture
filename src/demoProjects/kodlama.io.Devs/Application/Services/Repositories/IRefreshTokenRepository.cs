using Core.Persistence.Repositories;
using Core.Security.Entities;

namespace Application.Services.Repositories
{
    public interface IRefreshTokenRepository : IAsyncRepository<RefreshToken>, IRepository<RefreshToken>
    {
        public Task<ICollection<RefreshToken>> GetAllOldActiveRefreshTokensAsync(User user, int ttl);
    }
}