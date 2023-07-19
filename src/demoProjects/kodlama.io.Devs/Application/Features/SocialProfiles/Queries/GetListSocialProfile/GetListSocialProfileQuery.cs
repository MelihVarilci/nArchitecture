using Application.Features.SocialProfiles.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.SocialProfiles.Queries.GetListSocialProfile
{
    public class GetListSocialProfileQuery : IRequest<SocialProfileListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSocialProfileQueryHandler : IRequestHandler<GetListSocialProfileQuery, SocialProfileListModel>
        {
            private readonly ISocialProfileRepository _socialProfileRepository;
            private readonly IMapper _mapper;

            public GetListSocialProfileQueryHandler(ISocialProfileRepository socialProfileRepository, IMapper mapper)
            {
                _socialProfileRepository = socialProfileRepository;
                _mapper = mapper;
            }

            public async Task<SocialProfileListModel> Handle(GetListSocialProfileQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialProfile> technologies = await _socialProfileRepository.GetListAsync(
                    include: x => x.Include(y => y.UserProfileFk)
                                   .Include(x => x.UserProfileFk.Claims)
                                   .Include(x => x.UserProfileFk.Tokens),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);

                return _mapper.Map<SocialProfileListModel>(technologies);
            }
        }
    }
}