using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public class AppUserTokenEntityConfiguration : EntityConfiguration<AppUserToken>
    {
        public override void Configure(EntityTypeBuilder<AppUserToken> builder)
        {
            base.Configure(builder);

            builder.ToTable("AppUserTokens");

            // Composite primary key consisting of the UserId, LoginProvider and Name
            //builder.HasKey(t => new { t.Id, t.UserId, t.LoginProvider });

            //builder.Property(i => i.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            // Limit the size of the composite key columns due to common DB restrictions
            builder.Property(t => t.UserId).HasColumnName("UserId");
            builder.Property(t => t.LoginProvider).HasColumnName("LoginProvider");
            builder.Property(t => t.Token).HasColumnName("Token");
            builder.Property(t => t.Expires).HasColumnName("Expires");
            builder.Property(t => t.Created).HasColumnName("Created");
            builder.Property(t => t.CreatedByIp).HasColumnName("CreatedByIp");
            builder.Property(t => t.Revoked).HasColumnName("Revoked");
            builder.Property(t => t.RevokedByIp).HasColumnName("RevokedByIp");
            builder.Property(t => t.ReplacedByToken).HasColumnName("ReplacedByToken");
            builder.Property(t => t.ReasonRevoked).HasColumnName("ReasonRevoked");

            // Not be mapped to a column
            builder.Ignore(t => t.Value);
            builder.Ignore(t => t.Name);
            builder.Ignore(t => t.IsExpired);
            builder.Ignore(t => t.IsRevoked);
            builder.Ignore(t => t.IsActive);

            builder.HasOne(t => t.User)
                   .WithMany(t => t.UserTokens)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}