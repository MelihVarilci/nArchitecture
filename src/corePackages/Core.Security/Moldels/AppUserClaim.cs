using Core.Persistence.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels
{
    public class AppUserClaim : IdentityUserClaim<int>, IEntity
    {
    }
}