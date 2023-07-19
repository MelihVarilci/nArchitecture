using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public class AppRoleClaimEntityConfiguration : EntityConfiguration<AppRoleClaim>
    {
        public override void Configure(EntityTypeBuilder<AppRoleClaim> builder)
        {
            base.Configure(builder);

            builder.ToTable("AppRoleClaims");

            builder.HasOne(t => t.Role)
                   .WithMany(t => t.RoleClaims)
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}