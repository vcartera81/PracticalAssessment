using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.DataAccessContract;

namespace PracticalAssessment.Business.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDto>> GetAll()
        {
            var allCategories = await _categoryRepository.ListAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(allCategories);
        }
    }
}
