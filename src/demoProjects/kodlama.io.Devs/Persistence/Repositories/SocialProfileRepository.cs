using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class SocialProfileRepository : EfRepositoryBase<SocialProfile, BaseDbContext>, ISocialProfileRepository
    {
        public SocialProfileRepository(BaseDbContext context) : base(context)
        {
        }
    }
}