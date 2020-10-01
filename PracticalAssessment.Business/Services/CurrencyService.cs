using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.DataAccessContract;

namespace PracticalAssessment.Business.Services
{
    public class CurrencyService : ICurrencyService
    {
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IMapper _mapper;

        public CurrencyService(ICurrencyRepository currencyRepository, IMapper mapper)
        {
            _currencyRepository = currencyRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CurrencyDto>> GetAll()
        {
            var allCurrencies = await _currencyRepository.ListAsync();
            return _mapper.Map<IEnumerable<CurrencyDto>>(allCurrencies);
        }
    }
}
