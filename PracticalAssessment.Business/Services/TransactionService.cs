using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.Business.Validation;
using PracticalAssessment.DataAccessContract;
using PracticalAssessment.DataAccessContract.Entities;

namespace PracticalAssessment.Business.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IValidator<TransactionDto> _validator;
        private readonly IMapper _mapper;

        public TransactionService(
            ITransactionRepository transactionRepository,
            IValidator<TransactionDto> validator,
            IMapper mapper)
        {
            _transactionRepository = transactionRepository;
            _validator = validator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TransactionDto>> GetAll()
        {
            var entities = await _transactionRepository.ListAsync();
            return _mapper.Map<IEnumerable<TransactionDto>>(entities);
        }

        public async Task<IEnumerable<GroupedTransactionDto>> GetAllGroupedByDate()
        {
            var grouped = await _transactionRepository.ListGroupedByDateAsync();

            return grouped.Select(g => new GroupedTransactionDto
            {
                Transactions = _mapper.Map<IEnumerable<TransactionDto>>(g),
                Date = g.Key,
                Balance = g.GetBalance()
            });
        }

        public async Task<int> Add(TransactionDto newTransaction)
        {
            await _validator.ValidateForAdding(newTransaction);

            var newTransactionEntity = _mapper.Map<Transaction>(newTransaction);

            var newId = await _transactionRepository.Add(newTransactionEntity);

            return newId;
        }

        public async Task Update(TransactionDto updatedTransaction)
        {
            await _validator.ValidateForUpdate(updatedTransaction);

            var updatedTransactionEntity = _mapper.Map<Transaction>(updatedTransaction);

            await _transactionRepository.Update(updatedTransactionEntity);
        }

        public async Task Delete(int transactionId)
        {
            await _validator.ValidateForDeletion(transactionId);

            await _transactionRepository.Remove(transactionId);
        }
    }
}