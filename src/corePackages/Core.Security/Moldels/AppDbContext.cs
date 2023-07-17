using Core.Security.EntityConfigurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Core.Security.Moldels
{
    public class AppDbContext<TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TSelf>
        : IdentityDbContext<TUser, TRole, int, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        where TUser : AppUser
        where TRole : AppRole
        where TUserClaim : AppUserClaim
        where TUserRole : AppUserRole
        where TUserLogin : AppUserLogin
        where TRoleClaim : AppRoleClaim
        where TUserToken : AppUserToken
        where TSelf : AppDbContext<TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TSelf>
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserClaim> AppUserClaims { get; set; }
        public DbSet<AppUserLogin> AppUserLogins { get; set; }
        public DbSet<AppUserToken> AppUserTokens { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppRoleClaim> AppRoleClaims { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }

        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

        public AppDbContext(DbContextOptions<TSelf> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-7.0
            base.OnModelCreating(modelBuilder);

            // Using Fluent API Methods for Entity Configurations
            // Apply all specified configurations on types that implement IEntityTypeConfiguration in an assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EntityConfiguration<AppUser>).Assembly);
        }
    }
}