using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Services.Repositories
{
    public interface IUserProfileRepository : IAsyncRepository<UserProfile>, IRepository<UserProfile>
    {
    }
}