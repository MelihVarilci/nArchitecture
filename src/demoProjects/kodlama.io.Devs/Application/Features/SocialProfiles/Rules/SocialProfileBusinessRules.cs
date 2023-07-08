using Application.Constants;
using Application.Services.Repositories;
using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;

namespace Application.Features.SocialProfiles.Rules
{
    public class SocialProfileBusinessRules : BaseBusinessRules
    {
        private readonly ISocialProfileRepository _socialProfileRepository;

        public SocialProfileBusinessRules(ISocialProfileRepository socialProfileRepository)
        {
            _socialProfileRepository = socialProfileRepository;
        }

        public Task UserProfileShouldBeExists(UserProfile? userProfile)
        {
            if (userProfile is null)
                throw new BusinessException(Messages.UserProfileNotFound);
            return Task.CompletedTask;
        }

        public void SocialProfileShouldExistWhenRequested(SocialProfile? socialProfile)
        {
            if (socialProfile == null) throw new BusinessException("Requested SocialProfile does not exist");
        }

        public Task UserAlreadyHasSocialProfile(SocialProfile? socialProfile)
        {
            if (socialProfile is not null)
                throw new BusinessException("The user already has a social profile");
            return Task.CompletedTask;
        }
    }
}