using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Business
{
    public interface IRecipientService
    {
        Task<IEnumerable<RecipientDto>> GetAll();

        Task Delete(int id);

        Task<int> Add(RecipientDto category);
    }
}
