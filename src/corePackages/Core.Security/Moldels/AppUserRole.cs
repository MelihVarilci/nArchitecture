using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels
{
    public class AppUserRole : IdentityUserRole<int>, IEntity
    {
        public int Id { get; set; }

        public virtual AppUser User { get; set; }
        public virtual AppRole Role { get; set; }
    }
}