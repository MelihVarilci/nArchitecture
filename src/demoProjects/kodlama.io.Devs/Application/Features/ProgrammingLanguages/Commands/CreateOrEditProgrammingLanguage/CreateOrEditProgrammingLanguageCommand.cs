using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.ProgrammingLanguages.Commands.CreateOrEditProgrammingLanguage
{
    public class CreateOrEditProgrammingLanguageCommand : IRequest<CreateOrEditProgrammingLanguageDto>
    {
        public int? Id { get; set; }
        public string Name { get; set; }

        public class CreateOrEditProgrammingLanguageCommandHandler : IRequestHandler<CreateOrEditProgrammingLanguageCommand, CreateOrEditProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public CreateOrEditProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<CreateOrEditProgrammingLanguageDto> Handle(CreateOrEditProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);

                if (request.Id == null || request.Id == 0)
                {
                    return await Create(mappedProgrammingLanguage);
                }
                else
                {
                    return await Update(mappedProgrammingLanguage);
                }
            }

            private async Task<CreateOrEditProgrammingLanguageDto> Create(ProgrammingLanguage mappedProgrammingLanguage)
            {
                ProgrammingLanguage createdProgrammingLanguage = await _programmingLanguageRepository.AddAsync(mappedProgrammingLanguage);
                CreateOrEditProgrammingLanguageDto createOrEditProgrammingLanguageDto = _mapper.Map<CreateOrEditProgrammingLanguageDto>(createdProgrammingLanguage);

                return createOrEditProgrammingLanguageDto;
            }

            private async Task<CreateOrEditProgrammingLanguageDto> Update(ProgrammingLanguage mappedProgrammingLanguage)
            {
                ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(mappedProgrammingLanguage);
                CreateOrEditProgrammingLanguageDto createOrEditProgrammingLanguageDto = _mapper.Map<CreateOrEditProgrammingLanguageDto>(updatedProgrammingLanguage);

                return createOrEditProgrammingLanguageDto;
            }
        }
    }
}