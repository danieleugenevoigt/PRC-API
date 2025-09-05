using Mapster;
using PRC.Api.DTO_s;
using PRC.Core.Interfaces;

namespace PRC.Api.Tasks
{
    public class CategoryTask
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryTask(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryResponse>> GetAllCategoriesAsync()
        {
            var categoryTransforms = await _categoryRepository.GetAllCategoriesAsync();
            return categoryTransforms.Adapt<IEnumerable<CategoryResponse>>();
        }

        public async Task<CategoryResponse?> GetCategoryByIdAsync(long id)
        {
            var categoryTransform = await _categoryRepository.GetCategoryByIdAsync(id);
            return categoryTransform?.Adapt<CategoryResponse>();
        }

        public async Task<CategoryResponse?> GetCategoryBySlugAsync(string slug)
        {
            var categoryTransform = await _categoryRepository.GetCategoryBySlugAsync(slug);
            return categoryTransform?.Adapt<CategoryResponse>();
        }
    }
}
