using Core.Security.EntityConfigurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class TechnologyEntityConfiguration : EntityConfiguration<Technology, int>
    {
        public override void Configure(EntityTypeBuilder<Technology> builder)
        {
            base.Configure(builder);

            builder.ToTable("Technologies");

            builder.Property(p => p.Name).HasColumnName("Name");

            builder.HasOne(p => p.ProgrammingLanguageFk)
                .WithMany(p => p.Technologies)
                .HasForeignKey(p => p.ProgrammingLanguageId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}