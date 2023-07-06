using Core.Persistence.Repositories;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class SocialProfile : Entity
    {
        public string? GithubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? PersonalWebSiteUrl { get; set; }
        public virtual int UserProfileId { get; set; }

        [ForeignKey("UserProfileId")]
        public UserProfile? UserProfileFk { get; set; }

        public SocialProfile()
        {
        }

        public SocialProfile(int id,
            string? githubUrl,
            string? linkedInUrl,
            string? ınstagramUrl,
            string? twitterUrl,
            string? personalWebSiteUrl,
            int userProfileId)
        {
            Id = id;
            GithubUrl = githubUrl;
            LinkedInUrl = linkedInUrl;
            InstagramUrl = ınstagramUrl;
            TwitterUrl = twitterUrl;
            PersonalWebSiteUrl = personalWebSiteUrl;
            UserProfileId = userProfileId;
        }
    }
}