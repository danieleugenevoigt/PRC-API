using PRC.Core.Transforms;

namespace PRC.Core.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductTransform>> GetAllProductsAsync();
        Task<ProductTransform?> GetProductByIdAsync(long id);
        Task<ProductTransform?> GetProductBySkuAsync(string sku);
        Task<IEnumerable<ProductTransform>> GetActiveProductsAsync();
    }
}
