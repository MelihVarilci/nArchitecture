using Core.Persistence.Repositories;
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

    public virtual ICollection<UserOperationClaim> OperationClaims { get; set; }
    public virtual ICollection<AppUserToken> UserTokens { get; set; }
    public virtual ICollection<AppUserRole> UserRoles { get; set; }

    public AppUser()
    {
        OperationClaims = new HashSet<UserOperationClaim>();
        UserTokens = new HashSet<AppUserToken>();
        UserRoles = new HashSet<AppUserRole>();
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