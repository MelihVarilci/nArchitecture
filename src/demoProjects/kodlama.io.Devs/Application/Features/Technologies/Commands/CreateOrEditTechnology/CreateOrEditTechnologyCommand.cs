using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.CreateOrEditTechnology
{
    public class CreateOrEditTechnologyCommand : IRequest<CreateOrEditTechnologyDto>
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public int ProgrammingLanguageId { get; set; }

        public class CreateOrEditTechnologyCommandHandler : IRequestHandler<CreateOrEditTechnologyCommand, CreateOrEditTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public CreateOrEditTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<CreateOrEditTechnologyDto> Handle(CreateOrEditTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

                Technology mappedTechnology = _mapper.Map<Technology>(request);

                if (request.Id == null || request.Id == 0)
                {
                    return await Create(mappedTechnology);
                }
                else
                {
                    return await Update(mappedTechnology);
                }
            }

            private async Task<CreateOrEditTechnologyDto> Create(Technology mappedTechnology)
            {
                Technology createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
                CreateOrEditTechnologyDto createOrEditTechnologyDto = _mapper.Map<CreateOrEditTechnologyDto>(createdTechnology);

                return createOrEditTechnologyDto;
            }

            private async Task<CreateOrEditTechnologyDto> Update(Technology mappedTechnology)
            {
                Technology updatedTechnology = await _technologyRepository.UpdateAsync(mappedTechnology);
                CreateOrEditTechnologyDto createOrEditTechnologyDto = _mapper.Map<CreateOrEditTechnologyDto>(updatedTechnology);

                return createOrEditTechnologyDto;
            }
        }
    }
}