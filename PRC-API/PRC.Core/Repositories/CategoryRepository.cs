using Microsoft.EntityFrameworkCore;
using PRC.Core.Interfaces;
using PRC.Core.Transforms;

namespace PRC.Core.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoryTransform>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Select(c => new CategoryTransform
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug
                })
                .ToListAsync();
        }

        public async Task<CategoryTransform?> GetCategoryByIdAsync(long id)
        {
            return await _context.Categories
                .Where(c => c.Id == id)
                .Select(c => new CategoryTransform
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug
                })
                .FirstOrDefaultAsync();
        }

        public async Task<CategoryTransform?> GetCategoryBySlugAsync(string slug)
        {
            return await _context.Categories
                .Where(c => c.Slug == slug)
                .Select(c => new CategoryTransform
                {
                    Id = c.Id,
                    Name = c.Name,
                    Slug = c.Slug
                })
                .FirstOrDefaultAsync();
        }
    }
}
