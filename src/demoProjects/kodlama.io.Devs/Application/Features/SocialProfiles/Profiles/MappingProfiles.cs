using Application.Features.SocialProfiles.Commands.CreateOrEditSocialProfile;
using Application.Features.SocialProfiles.Dtos;
using Application.Features.SocialProfiles.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.SocialProfiles.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialProfile, CreateOrEditSocialProfileDto>().ReverseMap();
            CreateMap<SocialProfile, CreateOrEditSocialProfileCommand>().ReverseMap();
            CreateMap<IPaginate<SocialProfile>, SocialProfileListModel>().ReverseMap();
            CreateMap<SocialProfile, SocialProfileListDto>().ReverseMap();
            CreateMap<SocialProfile, SocialProfileGetByIdDto>().ReverseMap();

            CreateMap<SocialProfile, DeleteSocialProfileDto>().ReverseMap();
        }
    }
}