using Core.Persistence.Entities;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels
{
    public class AppRoleClaim : IdentityRoleClaim<int>, IEntity
    {
        public AppRole Role { get; set; }
    }
}