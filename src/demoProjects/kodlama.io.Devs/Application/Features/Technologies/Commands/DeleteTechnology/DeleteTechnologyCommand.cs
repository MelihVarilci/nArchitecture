using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeleteTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteTechnologyCommandQuery : IRequestHandler<DeleteTechnologyCommand, DeleteTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandQuery(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<DeleteTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                Technology technology = await _technologyRepository.GetAsync(x => x.Id == request.Id);
                _technologyBusinessRules.TechnologyShouldExistWhenRequested(technology);

                await _technologyRepository.DeleteAsync(technology);
                DeleteTechnologyDto deleteTechnologyDto = _mapper.Map<DeleteTechnologyDto>(technology);

                return deleteTechnologyDto;
            }
        }
    }
}