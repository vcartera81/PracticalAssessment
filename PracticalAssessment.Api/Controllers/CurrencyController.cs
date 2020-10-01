using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalAssessment.Business;

namespace PracticalAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService) => _currencyService = currencyService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _currencyService.GetAll());
    }
}
