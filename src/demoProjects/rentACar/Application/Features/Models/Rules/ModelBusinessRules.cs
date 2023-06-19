using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;

namespace Application.Features.Models.Rules
{
    public class ModelBusinessRules
    {
        private readonly IModelRepository _modelRepository;

        public ModelBusinessRules(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        public async Task ModelNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Model> result = await _modelRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Model name exists.");
        }
    }
}