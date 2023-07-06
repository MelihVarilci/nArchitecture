using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class UserProfileRepository : EfRepositoryBase<UserProfile, BaseDbContext>, IUserProfileRepository
    {
        public UserProfileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}