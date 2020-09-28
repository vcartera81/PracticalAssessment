using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalAssessment.Business;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService) => _transactionService = transactionService;

        [HttpGet]
        public async Task<IEnumerable<TransactionDto>> GetAll() => await _transactionService.GetAll();
    }
}
