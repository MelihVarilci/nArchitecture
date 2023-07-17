using Application.Features.OperationClaims.Commands.CreateOrEditOperationClaim;
using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Models;
using Application.Features.ProgrammingLanguages.Commands.CreateOrEditProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.SocialProfiles.Commands.CreateOrEditSocialProfile;
using Application.Features.SocialProfiles.Dtos;
using Application.Features.SocialProfiles.Models;
using Application.Features.Technologies.Commands.CreateOrEditTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.UserOperationClaims.Commands.CreateOrEditUserOperationClaim;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Dtos;
using Core.Security.Moldels;
using Domain.Entities;

namespace Application.Mappings
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            #region User

            CreateMap<AppUser, UserForRegisterDto>().ReverseMap();
            CreateMap<UserProfile, UserForRegisterDto>().ReverseMap();

            #endregion User

            #region UserOperationClaim

            CreateMap<UserOperationClaim, CreateOrEditUserOperationClaimDto>().ReverseMap();
            CreateMap<UserOperationClaim, CreateOrEditUserOperationClaimCommand>().ReverseMap();
            CreateMap<IPaginate<UserOperationClaim>, UserOperationClaimListModel>().ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimListDto>().ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimGetByIdDto>().ReverseMap();

            CreateMap<UserOperationClaim, DeleteUserOperationClaimDto>().ReverseMap();

            #endregion UserOperationClaim

            #region OperationClaim

            CreateMap<OperationClaim, CreateOrEditOperationClaimDto>().ReverseMap();
            CreateMap<OperationClaim, CreateOrEditOperationClaimCommand>().ReverseMap();
            CreateMap<IPaginate<OperationClaim>, OperationClaimListModel>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimListDto>().ReverseMap();
            CreateMap<OperationClaim, OperationClaimGetByIdDto>().ReverseMap();

            CreateMap<OperationClaim, DeleteOperationClaimDto>().ReverseMap();

            #endregion OperationClaim

            #region ProgrammingLanguage

            CreateMap<ProgrammingLanguage, CreateOrEditProgrammingLanguageDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, CreateOrEditProgrammingLanguageCommand>().ReverseMap();
            CreateMap<IPaginate<ProgrammingLanguage>, ProgrammingLanguageListModel>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageListDto>().ReverseMap();
            CreateMap<ProgrammingLanguage, ProgrammingLanguageGetByIdDto>().ReverseMap();

            CreateMap<ProgrammingLanguage, DeleteProgrammingLanguageDto>().ReverseMap();

            #endregion ProgrammingLanguage

            #region Technology

            CreateMap<Technology, CreateOrEditTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateOrEditTechnologyCommand>().ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyListModel>().ReverseMap();
            CreateMap<Technology, TechnologyListDto>().ReverseMap();
            CreateMap<Technology, TechnologyGetByIdDto>().ReverseMap();

            CreateMap<Technology, DeleteTechnologyDto>().ReverseMap();

            #endregion Technology

            #region SocialProfile

            CreateMap<SocialProfile, CreateOrEditSocialProfileDto>().ReverseMap();
            CreateMap<SocialProfile, CreateOrEditSocialProfileCommand>().ReverseMap();
            CreateMap<IPaginate<SocialProfile>, SocialProfileListModel>().ReverseMap();
            CreateMap<SocialProfile, SocialProfileListDto>().ReverseMap();
            CreateMap<SocialProfile, SocialProfileGetByIdDto>().ReverseMap();

            CreateMap<SocialProfile, DeleteSocialProfileDto>().ReverseMap();

            #endregion SocialProfile
        }
    }
}