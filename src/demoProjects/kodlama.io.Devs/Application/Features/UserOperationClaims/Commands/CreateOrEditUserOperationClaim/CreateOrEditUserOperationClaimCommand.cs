using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.UserOperationClaims.Commands.CreateOrEditUserOperationClaim
{
    public class CreateOrEditUserOperationClaimCommand : IRequest<CreateOrEditUserOperationClaimDto>
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public int OperationClaimId { get; set; }

        public class CreateOrEditUserOperationClaimCommandHandler : IRequestHandler<CreateOrEditUserOperationClaimCommand, CreateOrEditUserOperationClaimDto>
        {
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            private readonly UserOperationClaimBusinessRules _userOperationClaimBusinessRules;

            public CreateOrEditUserOperationClaimCommandHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper, UserOperationClaimBusinessRules userOperationClaimBusinessRules)
            {
                _userOperationClaimRepository = userOperationClaimRepository;
                _mapper = mapper;
                _userOperationClaimBusinessRules = userOperationClaimBusinessRules;
            }

            public async Task<CreateOrEditUserOperationClaimDto> Handle(CreateOrEditUserOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _userOperationClaimBusinessRules.UserShouldBeExist(request.UserId);
                await _userOperationClaimBusinessRules.OperationClaimShouldBeExist(request.OperationClaimId);

                UserOperationClaim mappedUserOperationClaim = _mapper.Map<UserOperationClaim>(request);

                if (request.Id == null || request.Id == 0)
                {
                    return await Create(mappedUserOperationClaim);
                }
                else
                {
                    return await Update(mappedUserOperationClaim);
                }
            }

            private async Task<CreateOrEditUserOperationClaimDto> Create(UserOperationClaim mappedUserOperationClaim)
            {
                UserOperationClaim createdUserOperationClaim = await _userOperationClaimRepository.AddAsync(mappedUserOperationClaim);
                CreateOrEditUserOperationClaimDto createOrEditUserOperationClaimDto = _mapper.Map<CreateOrEditUserOperationClaimDto>(createdUserOperationClaim);

                return createOrEditUserOperationClaimDto;
            }

            private async Task<CreateOrEditUserOperationClaimDto> Update(UserOperationClaim mappedUserOperationClaim)
            {
                UserOperationClaim updatedUserOperationClaim = await _userOperationClaimRepository.UpdateAsync(mappedUserOperationClaim);
                CreateOrEditUserOperationClaimDto createOrEditUserOperationClaimDto = _mapper.Map<CreateOrEditUserOperationClaimDto>(updatedUserOperationClaim);

                return createOrEditUserOperationClaimDto;
            }
        }
    }
}