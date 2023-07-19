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

            builder.Property(i => i.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(t => t.UserId).HasColumnName("UserId");
            builder.Property(l => l.LoginProvider).HasMaxLength(128).HasColumnName("LoginProvider");
            builder.Property(l => l.ProviderKey).HasMaxLength(128).HasColumnName("ProviderKey");

            builder.HasOne(t => t.User)
                   .WithMany(t => t.Logins)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}