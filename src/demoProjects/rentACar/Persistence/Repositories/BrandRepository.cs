using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entites;
using Persistence.Contexts;

namespace Persistence.Repositories
{
    public class BrandRepository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
    {
        public BrandRepository(BaseDbContext context) : base(context)
        {
        }
    }
}