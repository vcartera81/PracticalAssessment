using System.Threading.Tasks;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.Business.Exception;
using PracticalAssessment.DataAccessContract;

namespace PracticalAssessment.Business.Validation
{
    public class TransactionValidator : ValidatorBase<TransactionDto>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly IRecipientRepository _recipientRepository;
        private readonly ITransactionRepository _transactionRepository;

        public TransactionValidator(
            ICategoryRepository categoryRepository,
            ICurrencyRepository currencyRepository,
            IRecipientRepository recipientRepository,
            ITransactionRepository transactionRepository)
        {
            _categoryRepository = categoryRepository;
            _currencyRepository = currencyRepository;
            _recipientRepository = recipientRepository;
            _transactionRepository = transactionRepository;
        }

        public override async Task ValidateForAdding(TransactionDto dto)
        {
            ValidateNotDefaultValue(dto.Recipient.Id, nameof(dto.Recipient));
            ValidateNotDefaultValue(dto.Category.Id, nameof(dto.Category));
            ValidateNotDefaultValue(dto.Currency.Id, nameof(dto.Currency));
            ValidateNotDefaultValue(dto.OccuredOn, nameof(dto.OccuredOn));
            ValidateNotDefaultValue(dto.Amount, nameof(dto.Amount));
            ValidateValueNotNullOrWhitespace(dto.Title, nameof(dto.Title));

            if (dto.Amount < 0)
                throw new BusinessException($"Amount should be greater than zero.");

            var categoryExists = await _categoryRepository.Exists(dto.Category.Id);
            if (!categoryExists)
                throw new BusinessException($"Category with ID {dto.Category.Id} does not exists.");

            var recipientExists = await _recipientRepository.Exists(dto.Recipient.Id);
            if (!recipientExists)
                throw new BusinessException($"Recipient with ID {dto.Recipient.Id} does not exists.");

            var currencyExists = await _currencyRepository.Exists(dto.Currency.Id);
            if (!currencyExists)
                throw new BusinessException($"Currency with ID {dto.Currency.Id} does not exists.");
        }

        public override async Task ValidateForUpdate(TransactionDto dto)
        {
            ValidateNotDefaultValue(dto.Id, nameof(dto.Id));

            var exists = await _transactionRepository.Exists(dto.Id);
            if(!exists)
                throw new BusinessException($"Transaction with ID {dto.Id} does not exists.");
        }

        public override async Task ValidateForDeletion(int id)
        {
            var exists = await _transactionRepository.Exists(id);
            if (!exists)
                throw new BusinessException($"Transaction with ID {id} does not exists.");
        }
    }
}
