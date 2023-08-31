using Core.Persistence.Entities;
using Core.Security.EntityConfigurations;
using Core.Security.Expressions;
using Core.Security.Extensions;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq.Expressions;
using System.Reflection;

namespace Core.Security.Moldels
{
    public class AppDbContext<TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TSelf>
        : IdentityDbContext<TUser, TRole, int, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken>
        where TUser : AppUser
        where TRole : AppRole
        where TUserClaim : AppUserClaim
        where TUserRole : AppUserRole
        where TUserLogin : AppUserLogin
        where TRoleClaim : AppRoleClaim
        where TUserToken : AppUserToken
        where TSelf : AppDbContext<TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TSelf>
    {
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<AppUserClaim> AppUserClaims { get; set; }
        public DbSet<AppUserLogin> AppUserLogins { get; set; }
        public DbSet<AppUserToken> AppUserTokens { get; set; }
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<AppRoleClaim> AppRoleClaims { get; set; }
        public DbSet<AppUserRole> AppUserRoles { get; set; }

        private static MethodInfo ConfigureGlobalFiltersMethodInfo =
            typeof(AppDbContext<TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TSelf>).GetMethod(nameof(ConfigureGlobalFilters), BindingFlags.Instance | BindingFlags.NonPublic);

        public AppDbContext(DbContextOptions<TSelf> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // https://learn.microsoft.com/en-us/aspnet/core/security/authentication/customize-identity-model?view=aspnetcore-7.0
            base.OnModelCreating(modelBuilder);

            // Using Fluent API Methods for Entity Configurations
            // Apply all specified configurations on types that implement IEntityTypeConfiguration in an assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext<TUser, TRole, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken, TSelf>).Assembly);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Model oluşturma sürecinde filtreleri yapılandırmak için çağrılır
                ConfigureGlobalFiltersMethodInfo
                    .MakeGenericMethod(entityType.ClrType)
                    .Invoke(this, new object[] { modelBuilder, entityType });
            }
        }

        /// <summary>
        /// Filtreleri yapılandırmak ve veritabanı sorgularına genel filtreler uygulamak için kullanılır
        /// </summary>
        protected void ConfigureGlobalFilters<TEntity>(ModelBuilder modelBuilder, IMutableEntityType entityType)
            where TEntity : class
        {
            if (entityType.BaseType == null && ShouldFilterEntity<TEntity>(entityType))
            {
                var filterExpression = CreateFilterExpression<TEntity>();
                if (filterExpression != null)
                {
                    modelBuilder.Entity<TEntity>().HasQueryFilter(filterExpression);
                }
            }
        }

        /// <summary>
        /// Belirtilen interface'leri implement eden entity'ler için filtre eklenmesi sağlayabilmek için true döndürür
        /// </summary>
        /// <returns>Eğer bir filtre eklenmesi gerekiyorsa true dönecektir</returns>
        protected virtual bool ShouldFilterEntity<TEntity>(IMutableEntityType entityType) where TEntity : class
        {
            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Belirli bir entity türü için filtre ifadesini oluşturur
        /// </summary>
        protected virtual Expression<Func<TEntity, bool>> CreateFilterExpression<TEntity>()
            where TEntity : class
        {
            Expression<Func<TEntity, bool>>? expression = null;

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                Expression<Func<TEntity, bool>> softDeleteFilter = e => !((ISoftDelete)e).IsDeleted;
                expression = expression == null ? softDeleteFilter : CombineExpressions(expression, softDeleteFilter);
            }

            return expression!;
        }

        /// <summary>
        /// Bu yöntem, filtreleri birleştirmek için kullanılır
        /// </summary>
        protected virtual Expression<Func<T, bool>> CombineExpressions<T>(Expression<Func<T, bool>> expression1, Expression<Func<T, bool>> expression2)
        {
            return ExpressionCombiner.Combine(expression1, expression2);
        }

        public override int SaveChanges()
        {
            try
            {
                ApplyAppConcepts();
                return base.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                ApplyAppConcepts();
                int result = await base.SaveChangesAsync(cancellationToken);

                return result;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Bu yöntem, uygulama kavramlarını işlemek için çağrılır.
        /// Yani, veritabanına yapılan değişiklikler öncesi ve sonrasında özel işlemler gerçekleştirir.
        /// </summary>
        protected virtual void ApplyAppConcepts()
        {
            foreach (var entry in ChangeTracker.Entries().ToList())
            {
                if (entry.State != EntityState.Modified && entry.CheckOwnedEntityChange())
                {
                    Entry(entry.Entity).State = EntityState.Modified;
                }

                ApplyAppConcepts(entry);
            }
        }

        protected virtual void ApplyAppConcepts(EntityEntry entry)
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    break;

                case EntityState.Modified:
                    break;

                case EntityState.Deleted:
                    CancelDeletionForSoftDelete(entry);
                    break;
            }
        }

        /// <summary>
        /// Bu yöntem, silinmeyi gerçekleştirmek yerine silinen nesnelerin durumunu değiştirerek,
        /// "soft-delete" özelliğini uygulamak için kullanılır.
        /// </summary>
        protected virtual void CancelDeletionForSoftDelete(EntityEntry entry)
        {
            if (entry.Entity is not ISoftDelete)
            {
                return;
            }

            entry.Reload();
            entry.State = EntityState.Modified;
            entry.Entity.As<ISoftDelete>().IsDeleted = true;
        }
    }
}