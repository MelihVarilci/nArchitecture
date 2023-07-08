using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserEntityConfiguration : EntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            builder.ToTable("Users");

            builder.Property(builder => builder.FirstName).HasColumnName("FirstName");
            builder.Property(builder => builder.LastName).HasColumnName("LastName");
            builder.Property(builder => builder.Email).HasColumnName("Email");
            builder.Property(builder => builder.PasswordSalt).HasColumnName("PasswordSalt");
            builder.Property(builder => builder.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(builder => builder.Status).HasColumnName("Status").HasDefaultValue(true);
            builder.Property(builder => builder.AuthenticatorType).HasColumnName("AuthenticatorType");

            builder.HasMany(builder => builder.UserOperationClaims);
            builder.HasMany(builder => builder.RefreshTokens);
        }
    }
}