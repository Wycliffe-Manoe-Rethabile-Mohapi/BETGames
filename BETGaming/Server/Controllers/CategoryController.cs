using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETGaming.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _CategoryService { get; }

        public CategoryController(ICategoryService categoryService)
        {
            _CategoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Category>>>> GetCategories()
        {
            var result = await _CategoryService.GetCategories();
            return Ok(result);
        }

    }
}
