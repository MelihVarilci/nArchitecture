using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class RefreshTokenRepository : EfRepositoryBase<RefreshToken, BaseDbContext>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<ICollection<RefreshToken>> GetAllOldActiveRefreshTokensAsync(User user, int ttl)
        {
            return await Query().Where(r => r.UserId == user.Id &&
                                            r.Revoked == null &&
                                            r.Expires > DateTime.UtcNow &&
                                            r.Created.AddMinutes(ttl) < DateTime.UtcNow // Çoklu oturum için esneklik süresi (RefreshTokenTTL)
                                            )
                                .ToListAsync();
        }
    }
}