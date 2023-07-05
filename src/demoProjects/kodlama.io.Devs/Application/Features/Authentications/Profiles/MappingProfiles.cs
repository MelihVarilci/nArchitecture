using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;

namespace Application.Features.Authentications.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, UserForRegisterDto>().ReverseMap();
        }
    }
}