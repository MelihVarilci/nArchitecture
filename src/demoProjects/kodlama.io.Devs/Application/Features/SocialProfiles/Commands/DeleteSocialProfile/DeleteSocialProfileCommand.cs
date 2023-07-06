using Application.Features.SocialProfiles.Dtos;
using Application.Features.SocialProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialProfiles.Commands.DeleteSocialProfile
{
    public class DeleteSocialProfileCommand : IRequest<DeleteSocialProfileDto>
    {
        public int Id { get; set; }

        public class DeleteSocialProfileCommandQuery : IRequestHandler<DeleteSocialProfileCommand, DeleteSocialProfileDto>
        {
            private readonly ISocialProfileRepository _socialProfileRepository;
            private readonly IMapper _mapper;
            private readonly SocialProfileBusinessRules _socialProfileBusinessRules;

            public DeleteSocialProfileCommandQuery(ISocialProfileRepository socialProfileRepository, IMapper mapper, SocialProfileBusinessRules socialProfileBusinessRules)
            {
                _socialProfileRepository = socialProfileRepository;
                _mapper = mapper;
                _socialProfileBusinessRules = socialProfileBusinessRules;
            }

            public async Task<DeleteSocialProfileDto> Handle(DeleteSocialProfileCommand request, CancellationToken cancellationToken)
            {
                SocialProfile socialProfile = await _socialProfileRepository.GetAsync(x => x.Id == request.Id);
                _socialProfileBusinessRules.SocialProfileShouldExistWhenRequested(socialProfile);

                await _socialProfileRepository.DeleteAsync(socialProfile);
                DeleteSocialProfileDto deleteSocialProfileDto = _mapper.Map<DeleteSocialProfileDto>(socialProfile);

                return deleteSocialProfileDto;
            }
        }
    }
}