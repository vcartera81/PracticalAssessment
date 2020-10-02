using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.Business.Validation;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.Business.Services
{
    public class RecipientService : IRecipientService
    {
        private readonly IRecipientRepository _recipientRepository;
        private readonly IValidator<RecipientDto> _validator;
        private readonly IMapper _mapper;

        public RecipientService(
            IRecipientRepository recipientRepository,
            IValidator<RecipientDto> validator,
            IMapper mapper)
        {
            _recipientRepository = recipientRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<RecipientDto>> GetAll()
        {
            var allRecipients = await _recipientRepository.ListAsync();
            return _mapper.Map<IEnumerable<RecipientDto>>(allRecipients);
        }

        public async Task<int> Add(RecipientDto recipient)
        {
            await _validator.ValidateForAdding(recipient);

            var recipientEntity = _mapper.Map<Recipient>(recipient);
            return await _recipientRepository.Add(recipientEntity);
        }

        public async Task Delete(int id)
        {
            await _validator.ValidateForDeletion(id);

            await _recipientRepository.Remove(id);
        }
    }
}
