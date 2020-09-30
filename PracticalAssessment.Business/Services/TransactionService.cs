using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PracticalAssessment.Business.DTO;
using PracticalAssessment.DataAccessContract;

namespace PracticalAssessment.Business.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IMapper _mapper;

        public TransactionService(ITransactionRepository transactionRepository, IMapper mapper)
        {
            _transactionRepository = transactionRepository;
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
    }
}
