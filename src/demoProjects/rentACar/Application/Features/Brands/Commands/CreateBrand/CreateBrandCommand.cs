using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entites;
using MediatR;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        public string Name { get; set; }

        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreateBrandCommandHandler(IBrandRepository someFeatureEntityRepository, IMapper mapper,
                                             BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = someFeatureEntityRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

                Brand mappedSomeFeatureEntity = _mapper.Map<Brand>(request);
                Brand createdSomeFeatureEntity = await _brandRepository.AddAsync(mappedSomeFeatureEntity);
                CreatedBrandDto CreatedBrandDto = _mapper.Map<CreatedBrandDto>(createdSomeFeatureEntity);

                return CreatedBrandDto;
            }
        }
    }
}