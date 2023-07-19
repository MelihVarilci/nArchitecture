using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class AppUserClaimRepository : EfRepositoryBase<AppUserClaim, BaseDbContext>, IAppUserClaimRepository
    {
        public AppUserClaimRepository(BaseDbContext context) : base(context)
        {
        }

        public async Task<ICollection<AppUserClaim>> GetOperationClaimsByUserIdAsync(int userId)
        {
            return await Query().AsNoTracking()
                                .Where(uoc => uoc.UserId == userId)
                                .Include(uoc => uoc.User)
                                .Select(uoc => new AppUserClaim
                                {
                                    Id = uoc.Id,
                                    UserId = uoc.UserId,
                                    User = uoc.User,
                                    ClaimType = uoc.ClaimType,
                                    ClaimValue = uoc.ClaimValue
                                }).ToListAsync();
        }
    }
}