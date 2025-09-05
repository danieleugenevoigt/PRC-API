using Microsoft.AspNetCore.Mvc;
using PRC.Api.Handlers;

namespace PRC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly CategoryHandler _categoryHandler;
        
        public CategoriesController(CategoryHandler categoryHandler)
        {
            _categoryHandler = categoryHandler;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            return await _categoryHandler.GetAllCategoriesAsync();
        }
        
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetCategory(long id)
        {
            return await _categoryHandler.GetCategoryByIdAsync(id);
        }
        
        [HttpGet("slug/{slug}")]
        public async Task<IActionResult> GetCategoryBySlug(string slug)
        {
            return await _categoryHandler.GetCategoryBySlugAsync(slug);
        }
    }
}
