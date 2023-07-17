using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public class OperationClaimEntityConfiguration : EntityConfiguration<OperationClaim>
    {
        public override void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable("OperationClaims");

            builder.Property(p => p.Name).HasColumnName("Name");
        }
    }
}