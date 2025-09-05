using PRC.Core.Transforms;

namespace PRC.Core.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryTransform>> GetAllCategoriesAsync();
        Task<CategoryTransform?> GetCategoryByIdAsync(long id);
        Task<CategoryTransform?> GetCategoryBySlugAsync(string slug);
    }
}
