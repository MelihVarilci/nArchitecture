using Core.Persistence.Repositories;
using Domain.Entites;

namespace Application.Services.Repositories
{
    public interface IBrandRepository : IAsyncRepository<Brand>, IRepository<Brand>
    {
    }
}