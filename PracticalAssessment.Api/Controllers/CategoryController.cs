using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PracticalAssessment.Business;
using PracticalAssessment.Business.DTO;

namespace PracticalAssessment.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService) => _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _categoryService.GetAll());

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryDto category) => Ok(await _categoryService.Add(category));

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _categoryService.Delete(id);
            return Ok();
        }
    }
}
