using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public class UserOperationClaimEntityConfiguration : EntityConfiguration<UserOperationClaim>
    {
        public override void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable("UserOperationClaims");

            builder.Property(builder => builder.UserId).HasColumnName("UserId");
            builder.Property(builder => builder.OperationClaimId).HasColumnName("OperationClaimId");

            builder.HasOne(builder => builder.OperationClaim);
            builder.HasOne(builder => builder.User);
        }
    }
}