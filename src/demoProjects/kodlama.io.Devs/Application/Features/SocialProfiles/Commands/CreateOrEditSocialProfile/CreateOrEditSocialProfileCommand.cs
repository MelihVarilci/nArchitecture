using Application.Features.SocialProfiles.Dtos;
using Application.Features.SocialProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialProfiles.Commands.CreateOrEditSocialProfile
{
    public class CreateOrEditSocialProfileCommand : IRequest<CreateOrEditSocialProfileDto>
    {
        public int? Id { get; set; }
        public string? GithubUrl { get; set; }
        public string? LinkedInUrl { get; set; }
        public string? InstagramUrl { get; set; }
        public string? TwitterUrl { get; set; }
        public string? PersonalWebSiteUrl { get; set; }
        public int UserProfileId { get; set; }

        public class CreateOrEditSocialProfileCommandHandler : IRequestHandler<CreateOrEditSocialProfileCommand, CreateOrEditSocialProfileDto>
        {
            private readonly ISocialProfileRepository _socialProfileRepository;
            private readonly IUserProfileRepository _userProfileRepository;
            private readonly IMapper _mapper;
            private readonly SocialProfileBusinessRules _socialProfileBusinessRules;

            public CreateOrEditSocialProfileCommandHandler(ISocialProfileRepository socialProfileRepository,
                IUserProfileRepository userProfileRepository,
                IMapper mapper,
                SocialProfileBusinessRules socialProfileBusinessRules)
            {
                _socialProfileRepository = socialProfileRepository;
                _userProfileRepository = userProfileRepository;
                _mapper = mapper;
                _socialProfileBusinessRules = socialProfileBusinessRules;
            }

            public async Task<CreateOrEditSocialProfileDto> Handle(CreateOrEditSocialProfileCommand request, CancellationToken cancellationToken)
            {
                SocialProfile mappedSocialProfile = _mapper.Map<SocialProfile>(request);

                UserProfile? userProfile = await _userProfileRepository.GetAsync(u => u.Id == request.UserProfileId);
                await _socialProfileBusinessRules.UserProfileShouldBeExists(userProfile);

                if (request.Id == null || request.Id == 0)
                {
                    return await Create(mappedSocialProfile);
                }
                else
                {
                    return await Update(mappedSocialProfile);
                }
            }

            private async Task<CreateOrEditSocialProfileDto> Create(SocialProfile mappedSocialProfile)
            {
                SocialProfile? socialProfile = await _socialProfileRepository.GetAsync(u => u.UserProfileId == mappedSocialProfile.UserProfileId);
                await _socialProfileBusinessRules.UserAlreadyHasSocialProfile(socialProfile);

                SocialProfile createdSocialProfile = await _socialProfileRepository.AddAsync(mappedSocialProfile);
                CreateOrEditSocialProfileDto createOrEditSocialProfileDto = _mapper.Map<CreateOrEditSocialProfileDto>(createdSocialProfile);

                return createOrEditSocialProfileDto;
            }

            private async Task<CreateOrEditSocialProfileDto> Update(SocialProfile mappedSocialProfile)
            {
                SocialProfile updatedSocialProfile = await _socialProfileRepository.UpdateAsync(mappedSocialProfile);
                CreateOrEditSocialProfileDto createOrEditSocialProfileDto = _mapper.Map<CreateOrEditSocialProfileDto>(updatedSocialProfile);

                return createOrEditSocialProfileDto;
            }
        }
    }
}