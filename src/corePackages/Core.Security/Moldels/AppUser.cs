using Core.Persistence.Entities;
using Core.Security.Enums;
using Microsoft.AspNetCore.Identity;

namespace Core.Security.Moldels;

public class AppUser : IdentityUser<int>, IEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public byte[] PasswordSalt { get; set; }
    public byte[] PasswordHash { get; set; }
    public bool IsActive { get; set; }
    public AuthenticatorType AuthenticatorType { get; set; }

    public virtual ICollection<AppUserClaim> Claims { get; set; }
    public virtual ICollection<AppUserLogin> Logins { get; set; }
    public virtual ICollection<AppUserToken> Tokens { get; set; }
    public virtual ICollection<AppUserRole> Roles { get; set; }

    public AppUser()
    {
        Claims = new HashSet<AppUserClaim>();
        Logins = new HashSet<AppUserLogin>();
        Tokens = new HashSet<AppUserToken>();
        Roles = new HashSet<AppUserRole>();
    }

    public AppUser(int id, string firstName, string lastName, string email, byte[] passwordSalt, byte[] passwordHash,
                bool status, AuthenticatorType authenticatorType) : this()
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        PasswordSalt = passwordSalt;
        PasswordHash = passwordHash;
        IsActive = status;
        AuthenticatorType = authenticatorType;
    }
}