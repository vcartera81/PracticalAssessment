using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalAssessment.Business;

namespace PracticalAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService) => _transactionService = transactionService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _transactionService.GetAll());

        [HttpGet]
        [Route("grouped")]
        public async Task<IActionResult> GetAllGroupedByDates() => Ok(await _transactionService.GetAllGroupedByDate());
    }
}
