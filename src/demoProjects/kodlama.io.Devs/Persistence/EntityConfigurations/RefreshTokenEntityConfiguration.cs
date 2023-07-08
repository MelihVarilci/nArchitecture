using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class RefreshTokenEntityConfiguration : EntityConfiguration<RefreshToken>
    {
        public override void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            base.Configure(builder);

            builder.ToTable("RefreshTokens");

            builder.Property(p => p.UserId).HasColumnName("UserId");
            builder.Property(p => p.Token).HasColumnName("Token");
            builder.Property(p => p.Expires).HasColumnName("Expires");
            builder.Property(p => p.Created).HasColumnName("Created");
            builder.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
            builder.Property(p => p.Revoked).HasColumnName("Revoked");
            builder.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
            builder.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
            builder.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");

            builder.HasOne(p => p.User);
        }
    }
}