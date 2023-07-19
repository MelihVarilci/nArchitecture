using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Moldels;
using MediatR;

namespace Application.Features.OperationClaims.Commands.DeleteOperationClaim
{
    public class DeleteOperationClaimCommand : IRequest<DeleteOperationClaimDto>
    {
        public int Id { get; set; }

        public class DeleteOperationClaimCommandQuery : IRequestHandler<DeleteOperationClaimCommand, DeleteOperationClaimDto>
        {
            private readonly IAppUserClaimRepository _appUserClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public DeleteOperationClaimCommandQuery(IAppUserClaimRepository appUserClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _appUserClaimRepository = appUserClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<DeleteOperationClaimDto> Handle(DeleteOperationClaimCommand request, CancellationToken cancellationToken)
            {
                AppUserClaim? userClaim = await _appUserClaimRepository.GetAsync(x => x.Id == request.Id);
                _operationClaimBusinessRules.OperationClaimShouldExistWhenRequested(userClaim);

                await _appUserClaimRepository.DeleteAsync(userClaim!);
                DeleteOperationClaimDto deleteOperationClaimDto = _mapper.Map<DeleteOperationClaimDto>(userClaim);

                return deleteOperationClaimDto;
            }
        }
    }
}