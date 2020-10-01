using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Business
{
    public interface IRecipientService
    {
        public Task<IEnumerable<RecipientDto>> GetAll();
    }
}
