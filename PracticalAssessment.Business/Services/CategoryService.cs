using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.Business.Validation;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<CategoryDto> _validator;
        private readonly IMapper _mapper;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IValidator<CategoryDto> validator,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var allCategories = await _categoryRepository.ListAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(allCategories);
        }

        public async Task<int> Add(CategoryDto category)
        {
            await _validator.ValidateForAdding(category);

            var categoryEntity = _mapper.Map<Category>(category);
            return await _categoryRepository.Add(categoryEntity);
        }

        public async Task Delete(int id)
        {
            await _validator.ValidateForDeletion(id);

            await _categoryRepository.Remove(id);
        }
    }
}
