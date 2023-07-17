using Core.Security.Moldels;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : AppDbContext<AppUser, AppRole, AppUserClaim, AppUserRole, AppUserLogin, AppRoleClaim, AppUserToken, BaseDbContext>
    {
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<SocialProfile> SocialProfiles { get; set; }

        public BaseDbContext(DbContextOptions<BaseDbContext> dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected IConfiguration Configuration { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Eğer konfigure edilmediyse burası çalışır. Normal şartlarda buraya girmez!
            if (!optionsBuilder.IsConfigured)
            {
                base.OnConfiguring(optionsBuilder.UseSqlServer(Configuration.GetConnectionString("KodlamaIoDevsConnectionString")));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}