using Domain.Entities;

namespace Application.Features.SocialProfiles.Dtos
{
    public class SocialProfileListDto
    {
        public int Id { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? PersonalWebSiteUrl { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfileFk { get; set; }
    }
}