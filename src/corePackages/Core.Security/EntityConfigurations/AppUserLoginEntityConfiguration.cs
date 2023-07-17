using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public class AppUserLoginEntityConfiguration : EntityConfiguration<AppUserLogin>
    {
        public override void Configure(EntityTypeBuilder<AppUserLogin> builder)
        {
            base.Configure(builder);

            builder.ToTable("AppUserLogins");

            // Composite primary key consisting of the LoginProvider and the key to use
            // with that provider
            builder.HasKey(l => new { l.LoginProvider, l.ProviderKey });

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(l => l.LoginProvider).HasMaxLength(128).HasColumnName("LoginProvider");
            builder.Property(l => l.ProviderKey).HasMaxLength(128).HasColumnName("ProviderKey");
        }
    }
}