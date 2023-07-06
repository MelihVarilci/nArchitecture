using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface ISocialProfileRepository : IAsyncRepository<SocialProfile>, IRepository<SocialProfile>
    {
    }
}