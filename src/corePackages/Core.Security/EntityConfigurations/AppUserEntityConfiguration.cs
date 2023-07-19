using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public class AppUserEntityConfiguration : EntityConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);

            builder.ToTable("AppUsers");

            builder.Property(builder => builder.FirstName).HasColumnName("FirstName");
            builder.Property(builder => builder.LastName).HasColumnName("LastName");
            builder.Property(builder => builder.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(builder => builder.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(builder => builder.IsActive).HasColumnName("IsActive").HasDefaultValue(true);
            builder.Property(builder => builder.AuthenticatorType).HasColumnName("AuthenticatorType");

            // Limit the size of columns to use efficient database types
            builder.Property(builder => builder.UserName).HasColumnName("UserName").HasMaxLength(256);
            builder.Property(builder => builder.NormalizedUserName).HasColumnName("NormalizedUserName").HasMaxLength(256);
            builder.Property(builder => builder.Email).HasColumnName("EmailAddress").HasMaxLength(256);
            builder.Property(builder => builder.NormalizedEmail).HasColumnName("NormalizedEmailAddress").HasMaxLength(256);

            // The relationships between User and other entity types
            // Note that these relationships are configured with no navigation properties

            builder.Property(builder => builder.EmailConfirmed).HasColumnName("IsEmailConfirmed");
            builder.Property(builder => builder.SecurityStamp).HasColumnName("SecurityStamp");

            // A concurrency token for use with the optimistic concurrency checking
            builder.Property(builder => builder.ConcurrencyStamp).HasColumnName("ConcurrencyStamp").IsConcurrencyToken();

            builder.Property(builder => builder.PhoneNumber).HasColumnName("PhoneNumber");
            builder.Property(builder => builder.PhoneNumberConfirmed).HasColumnName("IsPhoneNumberConfirmed");
            builder.Property(builder => builder.TwoFactorEnabled).HasColumnName("IsTwoFactorEnabled");
            builder.Property(builder => builder.LockoutEnd).HasColumnName("LockoutEnd");
            builder.Property(builder => builder.LockoutEnabled).HasColumnName("IsLockoutEnabled");
            builder.Property(builder => builder.AccessFailedCount).HasColumnName("AccessFailedCount");

            // Indexes for "normalized" username and email, to allow efficient lookups
            builder.HasIndex(p => p.Email).IsUnique();
            builder.HasIndex(p => p.NormalizedEmail).IsUnique();
            builder.HasIndex(p => p.UserName).IsUnique();
            builder.HasIndex(p => p.NormalizedUserName).IsUnique();

            // Each User can have many UserClaims
            //builder.HasMany<AppUserClaim>().WithOne(x => x.User).HasForeignKey(uc => uc.UserId).IsRequired();

            // Each User can have many UserLogins
            builder.HasMany<AppUserLogin>().WithOne(x => x.User).HasForeignKey(ul => ul.UserId).IsRequired();

            // Each User can have many UserTokens
            builder.HasMany<AppUserToken>().WithOne(x => x.User).HasForeignKey(ut => ut.UserId).IsRequired();

            // Each User can have many entries in the UserRole join table
            builder.HasMany<AppUserRole>().WithOne(x => x.User).HasForeignKey(ur => ur.UserId).IsRequired();
        }
    }
}