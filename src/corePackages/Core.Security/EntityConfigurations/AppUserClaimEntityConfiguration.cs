using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public class AppUserClaimEntityConfiguration : EntityConfiguration<AppUserClaim, int>
    {
        public override void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable("AppUserClaims");

            builder.Property(t => t.UserId).HasColumnName("UserId");

            builder.HasOne(t => t.User)
                   .WithMany(t => t.Claims)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}