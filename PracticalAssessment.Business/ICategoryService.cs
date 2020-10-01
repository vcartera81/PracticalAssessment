using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Business
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryDto>> GetAll();

        Task<int> Add(CategoryDto category);

        Task Delete(int id);
    }
}
