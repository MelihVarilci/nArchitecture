using Core.Persistence.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Core.Security.EntityConfigurations
{
    public abstract class EntityConfiguration<TEntity, TPrimaryKey> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            // Primary key
            builder.HasKey(x => x.Id);

            builder.Property(i => i.Id).HasColumnName("Id").ValueGeneratedOnAdd();
        }
    }
}