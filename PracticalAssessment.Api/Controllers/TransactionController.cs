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
        public async Task<IActionResult> GetAll() => Ok(await _transactionService.GetAll());

        [HttpGet]
        [Route("grouped")]
        public async Task<IActionResult> GetAllGroupedByDates() => Ok(await _transactionService.GetAllGroupedByDate());

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] TransactionDto newTransaction) => Ok(await _transactionService.Add(newTransaction));

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] TransactionDto newTransaction)
        {
            await _transactionService.Update(newTransaction);
            return Ok();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _transactionService.Delete(id);
            return Ok();
        }
    }
}
