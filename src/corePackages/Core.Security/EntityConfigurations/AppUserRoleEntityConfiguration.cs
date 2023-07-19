using Core.Security.Moldels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public class AppUserRoleEntityConfiguration : EntityConfiguration<AppUserRole>
    {
        public override void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            base.Configure(builder);

            builder.ToTable("AppUserRoles");

            builder.Property(builder => builder.UserId).HasColumnName("UserId");
            builder.Property(builder => builder.RoleId).HasColumnName("RoleId");

            builder.HasOne(t => t.User)
                   .WithMany(t => t.Roles)
                   .HasForeignKey(x => x.UserId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();

            builder.HasOne(t => t.Role)
                   .WithMany(t => t.UserRoles)
                   .HasForeignKey(x => x.RoleId)
                   .OnDelete(DeleteBehavior.NoAction)
                   .IsRequired();
        }
    }
}