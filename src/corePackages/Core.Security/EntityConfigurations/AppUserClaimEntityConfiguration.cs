using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public class AppUserClaimEntityConfiguration : EntityConfiguration<AppUserClaim>
    {
        public override void Configure(EntityTypeBuilder<AppUserClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable("AppUserClaims");
        }
    }
}