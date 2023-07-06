using Application.Features.SocialProfiles.Dtos;
using Application.Features.SocialProfiles.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.SocialProfiles.Queries.GetByIdSocialProfile
{
    public class GetByIdSocialProfileQuery : IRequest<SocialProfileGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdSocialProfileQueryHandler : IRequestHandler<GetByIdSocialProfileQuery, SocialProfileGetByIdDto>
        {
            private readonly ISocialProfileRepository _socialProfileRepository;
            private readonly IMapper _mapper;
            private readonly SocialProfileBusinessRules _socialProfileBusinessRules;

            public GetByIdSocialProfileQueryHandler(ISocialProfileRepository socialProfileRepository, IMapper mapper, SocialProfileBusinessRules socialProfileBusinessRules)
            {
                _socialProfileRepository = socialProfileRepository;
                _mapper = mapper;
                _socialProfileBusinessRules = socialProfileBusinessRules;
            }

            public async Task<SocialProfileGetByIdDto> Handle(GetByIdSocialProfileQuery request, CancellationToken cancellationToken)
            {
                SocialProfile socialProfile = await _socialProfileRepository.GetAsync(x => x.Id == request.Id);
                _socialProfileBusinessRules.SocialProfileShouldExistWhenRequested(socialProfile);

                SocialProfileGetByIdDto socialProfileGetByIdDto = _mapper.Map<SocialProfileGetByIdDto>(socialProfile);
                return socialProfileGetByIdDto;
            }
        }
    }
}