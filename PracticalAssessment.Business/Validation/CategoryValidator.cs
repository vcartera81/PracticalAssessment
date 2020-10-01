using System;
using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.Business.Exception;
using PracticalAssessment.DataAccessContract;

namespace PracticalAssessment.Business.Validation
{
    public class CategoryValidator : ValidatorBase<CategoryDto>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryValidator(ICategoryRepository categoryRepository) => _categoryRepository = categoryRepository;

        public override async Task ValidateForAdding(CategoryDto dto)
        {
            var nameExists = await _categoryRepository.NameExists(dto.Name);
            if(nameExists)
                throw new BusinessException($"There's already a category with name '{dto.Name}'.");
        }

        public override Task ValidateForUpdate(CategoryDto dto) => throw new NotSupportedException();

        public override async Task ValidateForDeletion(int id)
        {
            var exists = await _categoryRepository.Exists(id);
            if (!exists)
                throw new BusinessException($"Category with ID {id} does not exists.");
        }
    }
}
