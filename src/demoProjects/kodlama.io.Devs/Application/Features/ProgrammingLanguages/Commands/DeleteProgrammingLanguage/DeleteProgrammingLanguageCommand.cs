﻿using Application.Constants;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using Core.Application.Pipelines.Transaction;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeleteProgrammingLanguageDto>, ICacheRemoverRequest, ISecuredRequest, ILoggableRequest, ITransactionableOperation
    {
        public int Id { get; set; }
        public bool BypassCache { get; set; }
        public List<string> CacheKeys => new() { $"ProgrammingLanguage-{Id}", "ProgrammingLanguageList" };

        public string[] Roles => new[] { Permissions.Pages_ProgrammingLanguage, Permissions.Pages_ProgrammingLanguage_Delete };

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguage = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                _programmingLanguageBusinessRules.ProgrammingLanguageShouldExistWhenRequested(programmingLanguage);

                await _programmingLanguageRepository.DeleteAsync(programmingLanguage);
                DeleteProgrammingLanguageDto deleteProgrammingLanguageDto = _mapper.Map<DeleteProgrammingLanguageDto>(programmingLanguage);

                return deleteProgrammingLanguageDto;
            }
        }
    }
}