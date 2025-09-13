using Microsoft.EntityFrameworkCore;
using PRC.Core.Interfaces;
using PRC.Core.Transforms;

namespace PRC.Core.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ProductTransform>> GetAllProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Categories)
                .Select(p => new ProductTransform
                {
                    Id = p.Id,
                    Sku = p.Sku,
                    SupplierCode = p.SupplierCode,
                    Title = p.Title,
                    Description = p.Description,
                    Qty = p.Qty,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    ProductImages = p.ProductImages.Select(pi => new ProductImageTransform
                    {
                        Id = pi.Id,
                        ProductId = pi.ProductId,
                        ImageUrl = pi.ImageUrl,
                        AltText = pi.AltText,
                        SortOrder = pi.SortOrder
                    }).OrderBy(pi => pi.SortOrder).ToList(),
                    Categories = p.Categories.Select(c => new CategoryTransform
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Slug = c.Slug
                    }).ToList(),
                    Rating = p.Rating
                })
                .ToListAsync();
        }

        public async Task<ProductTransform?> GetProductByIdAsync(long id)
        {
            return await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Categories)
                .Where(p => p.Id == id)
                .Select(p => new ProductTransform
                {
                    Id = p.Id,
                    Sku = p.Sku,
                    SupplierCode = p.SupplierCode,
                    Title = p.Title,
                    Description = p.Description,
                    Qty = p.Qty,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    ProductImages = p.ProductImages.Select(pi => new ProductImageTransform
                    {
                        Id = pi.Id,
                        ProductId = pi.ProductId,
                        ImageUrl = pi.ImageUrl,
                        AltText = pi.AltText,
                        SortOrder = pi.SortOrder
                    }).OrderBy(pi => pi.SortOrder).ToList(),
                    Categories = p.Categories.Select(c => new CategoryTransform
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Slug = c.Slug
                    }).ToList(),
                    Rating = p.Rating
                })
                .FirstOrDefaultAsync();
        }

        public async Task<ProductTransform?> GetProductBySkuAsync(string sku)
        {
            return await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Categories)
                .Where(p => p.Sku == sku)
                .Select(p => new ProductTransform
                {
                    Id = p.Id,
                    Sku = p.Sku,
                    SupplierCode = p.SupplierCode,
                    Title = p.Title,
                    Description = p.Description,
                    Qty = p.Qty,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    ProductImages = p.ProductImages.Select(pi => new ProductImageTransform
                    {
                        Id = pi.Id,
                        ProductId = pi.ProductId,
                        ImageUrl = pi.ImageUrl,
                        AltText = pi.AltText,
                        SortOrder = pi.SortOrder
                    }).OrderBy(pi => pi.SortOrder).ToList(),
                    Categories = p.Categories.Select(c => new CategoryTransform
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Slug = c.Slug
                    }).ToList(),
                    Rating = p.Rating
                })
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductTransform>> GetActiveProductsAsync()
        {
            return await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.Categories)
                .Where(p => p.IsActive)
                .Select(p => new ProductTransform
                {
                    Id = p.Id,
                    Sku = p.Sku,
                    SupplierCode = p.SupplierCode,
                    Title = p.Title,
                    Description = p.Description,
                    Qty = p.Qty,
                    Price = p.Price,
                    IsActive = p.IsActive,
                    CreatedAt = p.CreatedAt,
                    UpdatedAt = p.UpdatedAt,
                    ProductImages = p.ProductImages.Select(pi => new ProductImageTransform
                    {
                        Id = pi.Id,
                        ProductId = pi.ProductId,
                        ImageUrl = pi.ImageUrl,
                        AltText = pi.AltText,
                        SortOrder = pi.SortOrder
                    }).OrderBy(pi => pi.SortOrder).ToList(),
                    Categories = p.Categories.Select(c => new CategoryTransform
                    {
                        Id = c.Id,
                        Name = c.Name,
                        Slug = c.Slug
                    }).ToList(),
                    Rating = p.Rating
                })
                .ToListAsync();
        }
    }
}
