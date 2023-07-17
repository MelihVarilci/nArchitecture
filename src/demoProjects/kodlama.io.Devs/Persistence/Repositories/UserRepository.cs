using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Moldels;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<AppUser, BaseDbContext>, IUserRepository
    {
        public UserRepository(BaseDbContext context) : base(context)
        {
        }
    }
}