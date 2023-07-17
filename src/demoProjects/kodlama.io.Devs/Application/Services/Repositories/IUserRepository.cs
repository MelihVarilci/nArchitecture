using Core.Persistence.Repositories;
using Core.Security.Moldels;

namespace Application.Services.Repositories
{
    public interface IUserRepository : IAsyncRepository<AppUser>, IRepository<AppUser>
    {
    }
}