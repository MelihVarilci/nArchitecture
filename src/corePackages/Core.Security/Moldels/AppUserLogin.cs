using Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels
{
    public class AppUserLogin : IdentityUserLogin<int>, IEntity
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
    }
}