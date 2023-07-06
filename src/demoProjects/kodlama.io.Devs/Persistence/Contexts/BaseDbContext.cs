using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        #region BaseEntities

        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        #endregion BaseEntities

        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public DbSet<Technology> Technologies { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<SocialProfile> SocialProfiles { get; set; }

        public BaseDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region BaseEntity

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(k => k.Id);

                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.FirstName).HasColumnName("FirstName");
                p.Property(p => p.LastName).HasColumnName("LastName");
                p.Property(p => p.Email).HasColumnName("Email");
                p.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                p.Property(p => p.Status).HasColumnName("Status").HasDefaultValue(true);
                p.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

                p.HasMany(p => p.UserOperationClaims);
                p.HasMany(p => p.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(k => k.Id);

                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(k => k.Id);

                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");

                p.HasOne(p => p.OperationClaim);
                p.HasOne(p => p.User);
            });

            modelBuilder.Entity<RefreshToken>(a =>
            {
                a.ToTable("RefreshTokens").HasKey(k => k.Id);

                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.UserId).HasColumnName("UserId");
                a.Property(p => p.Token).HasColumnName("Token");
                a.Property(p => p.Expires).HasColumnName("Expires");
                a.Property(p => p.Created).HasColumnName("Created");
                a.Property(p => p.CreatedByIp).HasColumnName("CreatedByIp");
                a.Property(p => p.Revoked).HasColumnName("Revoked");
                a.Property(p => p.RevokedByIp).HasColumnName("RevokedByIp");
                a.Property(p => p.ReplacedByToken).HasColumnName("ReplacedByToken");
                a.Property(p => p.ReasonRevoked).HasColumnName("ReasonRevoked");

                a.HasOne(p => p.User);
            });

            #endregion BaseEntity

            modelBuilder.Entity<ProgrammingLanguage>(a =>
            {
                a.ToTable("ProgrammingLanguages").HasKey(k => k.Id);

                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(x => x.Technologies);
            });

            modelBuilder.Entity<Technology>(x =>
            {
                x.ToTable("Technologies").HasKey(k => k.Id);

                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.Name).HasColumnName("Name");

                x.HasOne(p => p.ProgrammingLanguageFk)
                    .WithMany(p => p.Technologies)
                    .HasForeignKey(p => p.ProgrammingLanguageId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserProfile>(x =>
            {
                x.ToTable("UserProfiles");

                x.HasOne(p => p.SocialProfile);
            });

            modelBuilder.Entity<SocialProfile>(x =>
            {
                x.ToTable("SocialProfiles").HasKey(k => k.Id);

                x.Property(p => p.Id).HasColumnName("Id");
                x.Property(p => p.GithubUrl).HasColumnName("GithubUrl");
                x.Property(p => p.LinkedInUrl).HasColumnName("LinkedInUrl");
                x.Property(p => p.InstagramUrl).HasColumnName("InstagramUrl");
                x.Property(p => p.TwitterUrl).HasColumnName("TwitterUrl");
                x.Property(p => p.PersonalWebSiteUrl).HasColumnName("PersonalWebSiteUrl");

                x.HasOne(p => p.UserProfileFk);
            });
        }
    }
}