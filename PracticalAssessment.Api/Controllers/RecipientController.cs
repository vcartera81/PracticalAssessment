using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalAssessment.Business;

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
    }
}
