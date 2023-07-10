using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;

namespace Application.Features.OperationClaims.Commands.CreateOrEditOperationClaim
{
    public class CreateOrEditOperationClaimCommand : IRequest<CreateOrEditOperationClaimDto>
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public class CreateOrEditOperationClaimCommandHandler : IRequestHandler<CreateOrEditOperationClaimCommand, CreateOrEditOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public CreateOrEditOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<CreateOrEditOperationClaimDto> Handle(CreateOrEditOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenInserted(request.Name);

                OperationClaim mappedOperationClaim = _mapper.Map<OperationClaim>(request);

                if (request.Id == null || request.Id == 0)
                {
                    return await Create(mappedOperationClaim);
                }
                else
                {
                    return await Update(mappedOperationClaim);
                }
            }

            private async Task<CreateOrEditOperationClaimDto> Create(OperationClaim mappedOperationClaim)
            {
                OperationClaim createdOperationClaim = await _operationClaimRepository.AddAsync(mappedOperationClaim);
                CreateOrEditOperationClaimDto createOrEditOperationClaimDto = _mapper.Map<CreateOrEditOperationClaimDto>(createdOperationClaim);

                return createOrEditOperationClaimDto;
            }

            private async Task<CreateOrEditOperationClaimDto> Update(OperationClaim mappedOperationClaim)
            {
                OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
                CreateOrEditOperationClaimDto createOrEditOperationClaimDto = _mapper.Map<CreateOrEditOperationClaimDto>(updatedOperationClaim);

                return createOrEditOperationClaimDto;
            }
        }
    }
}