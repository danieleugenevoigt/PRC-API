using Microsoft.AspNetCore.Mvc;
using PRC.Api.Tasks;

namespace PRC.Api.Handlers
{
    public class CategoryHandler
    {
        private readonly CategoryTask _categoryTask;

        public CategoryHandler(CategoryTask categoryTask)
        {
            _categoryTask = categoryTask;
        }

        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            try
            {
                var categories = await _categoryTask.GetAllCategoriesAsync();
                
                if (!categories.Any())
                    return new NotFoundResult();

                return new OkObjectResult(categories);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> GetCategoryByIdAsync(long id)
        {
            try
            {
                if (id <= 0)
                    return new BadRequestObjectResult("Invalid category ID");

                var category = await _categoryTask.GetCategoryByIdAsync(id);
                
                if (category == null)
                    return new NotFoundResult();

                return new OkObjectResult(category);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> GetCategoryBySlugAsync(string slug)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(slug))
                    return new BadRequestObjectResult("Slug cannot be empty");

                var category = await _categoryTask.GetCategoryBySlugAsync(slug);
                
                if (category == null)
                    return new NotFoundResult();

                return new OkObjectResult(category);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
                return new StatusCodeResult(500);
            }
        }
    }
}
