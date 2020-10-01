using System.Collections.Generic;
using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Business
{
    public interface ICurrencyService
    {
        public Task<IEnumerable<CurrencyDto>> GetAll();
    }
}
