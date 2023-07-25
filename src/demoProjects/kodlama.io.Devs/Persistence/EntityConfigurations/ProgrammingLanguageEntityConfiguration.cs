using Core.Security.EntityConfigurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class ProgrammingLanguageEntityConfiguration : EntityConfiguration<ProgrammingLanguage, int>
    {
        public override void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            base.Configure(builder);

            builder.ToTable("ProgrammingLanguages");

            builder.Property(p => p.Name).HasColumnName("Name");

            builder.HasMany(x => x.Technologies);
        }
    }
}