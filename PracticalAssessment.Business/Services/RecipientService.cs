using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.DataAccessContract;

namespace PracticalAssessment.Business.Services
{
    public class RecipientService : IRecipientService
    {
        private readonly IRecipientRepository _recipientRepository;
        private readonly IMapper _mapper;

        public RecipientService(IRecipientRepository recipientRepository, IMapper mapper)
        {
            _recipientRepository = recipientRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipientDto>> GetAll()
        {
            var allRecipients = await _recipientRepository.ListAsync();
            return _mapper.Map<IEnumerable<RecipientDto>>(allRecipients);
        }
    }
}
