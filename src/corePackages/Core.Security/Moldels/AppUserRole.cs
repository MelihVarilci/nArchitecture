using Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels
{
    public class AppUserRole : IdentityUserRole<int>, IEntity
    {
        public int Id { get; set; }

        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}