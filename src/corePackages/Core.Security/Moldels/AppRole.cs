using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels
{
    public class AppRole : IdentityRole<int>, IEntity
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
    }
}