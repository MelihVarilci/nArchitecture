using Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels
{
    public class AppRole : IdentityRole<int>, IEntity
    {
        public virtual ICollection<AppUserRole> UserRoles { get; set; }
        public virtual ICollection<AppRoleClaim> RoleClaims { get; set; }

        public AppRole()
        {
            UserRoles = new HashSet<AppUserRole>();
            RoleClaims = new HashSet<AppRoleClaim>();
        }

        public AppRole(int id) : this()
        {
            Id = id;
        }
    }
}