using System;
using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.Business.Exception;
using PracticalAssessment.DataAccessContract;

namespace PracticalAssessment.Business.Validation
{
    public class RecipientValidator : ValidatorBase<RecipientDto>
    {
        private readonly IRecipientRepository _recipientRepository;

        public RecipientValidator(IRecipientRepository recipientRepository) => _recipientRepository = recipientRepository;

        public override async Task ValidateForAdding(RecipientDto dto)
        {
            var nameExists = await _recipientRepository.NameExists(dto.Name);
            if (nameExists)
                throw new BusinessException($"There's already an recipient with name '{dto.Name}'.");
        }

        public override Task ValidateForUpdate(RecipientDto dto) => throw new NotSupportedException();

        public override async Task ValidateForDeletion(int id)
        {
            var exists = await _recipientRepository.Exists(id);
            if (!exists)
                throw new BusinessException($"Recipient with ID {id} does not exists.");
        }
    }
}
