using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalAssessment.Business;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecipientController : ControllerBase
    {
        private readonly IRecipientService _recipientService;

        public RecipientController(IRecipientService recipientService) => _recipientService = recipientService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _recipientService.GetAll());

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] RecipientDto category) => Ok(await _recipientService.Add(category));

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _recipientService.Delete(id);
            return Ok();
        }
    }
}
