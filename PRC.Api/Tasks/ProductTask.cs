using Mapster;
using PRC.Api.DTO_s;
using PRC.Core.Interfaces;

namespace PRC.Api.Tasks
{
    public class ProductTask
    {
        private readonly IProductRepository _productRepository;

        public ProductTask(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<ProductResponse>> GetAllProductsAsync()
        {
            var productTransforms = await _productRepository.GetAllProductsAsync();
            return productTransforms.Adapt<IEnumerable<ProductResponse>>();
        }

        public async Task<ProductResponse?> GetProductByIdAsync(long id)
        {
            var productTransform = await _productRepository.GetProductByIdAsync(id);
            return productTransform?.Adapt<ProductResponse>();
        }

        public async Task<ProductResponse?> GetProductBySkuAsync(string sku)
        {
            var productTransform = await _productRepository.GetProductBySkuAsync(sku);
            return productTransform?.Adapt<ProductResponse>();
        }

        public async Task<IEnumerable<ProductResponse>> GetActiveProductsAsync()
        {
            var productTransforms = await _productRepository.GetActiveProductsAsync();
            return productTransforms.Adapt<IEnumerable<ProductResponse>>();
        }
    }
}
