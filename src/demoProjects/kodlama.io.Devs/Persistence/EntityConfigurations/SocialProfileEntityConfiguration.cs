using Core.Security.EntityConfigurations;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class SocialProfileEntityConfiguration : EntityConfiguration<SocialProfile>
    {
        public override void Configure(EntityTypeBuilder<SocialProfile> builder)
        {
            base.Configure(builder);

            builder.ToTable("SocialProfiles");

            builder.Property(p => p.GithubUrl).HasColumnName("GithubUrl");
            builder.Property(p => p.LinkedInUrl).HasColumnName("LinkedInUrl");
            builder.Property(p => p.InstagramUrl).HasColumnName("InstagramUrl");
            builder.Property(p => p.TwitterUrl).HasColumnName("TwitterUrl");
            builder.Property(p => p.PersonalWebSiteUrl).HasColumnName("PersonalWebSiteUrl");

            builder.HasOne(p => p.UserProfileFk);
        }
    }
}