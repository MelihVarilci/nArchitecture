using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels
{
    public class AppUserLogin : IdentityUserLogin<int>, IEntity
    {
        public int Id { get; set; }
    }
}