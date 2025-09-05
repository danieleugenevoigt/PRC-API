using Microsoft.AspNetCore.Mvc;
using PRC.Api.DTO_s;
using PRC.Api.Tasks;

namespace PRC.Api.Handlers
{
    public class ProductHandler
    {
        private readonly ProductTask _productTask;

        public ProductHandler(ProductTask productTask)
        {
            _productTask = productTask;
        }

        public async Task<IActionResult> GetAllProductsAsync()
        {
            try
            {
                var products = await _productTask.GetAllProductsAsync();
                
                if (!products.Any())
                    return new NotFoundResult();

                return new OkObjectResult(products);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> GetProductByIdAsync(long id)
        {
            try
            {
                if (id <= 0)
                    return new BadRequestObjectResult("Invalid product ID");

                var product = await _productTask.GetProductByIdAsync(id);
                
                if (product == null)
                    return new NotFoundResult();

                return new OkObjectResult(product);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> GetProductBySkuAsync(string sku)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sku))
                    return new BadRequestObjectResult("SKU cannot be empty");

                var product = await _productTask.GetProductBySkuAsync(sku);
                
                if (product == null)
                    return new NotFoundResult();

                return new OkObjectResult(product);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
                return new StatusCodeResult(500);
            }
        }

        public async Task<IActionResult> GetActiveProductsAsync()
        {
            try
            {
                var products = await _productTask.GetActiveProductsAsync();
                
                if (!products.Any())
                    return new NotFoundResult();

                return new OkObjectResult(products);
            }
            catch (Exception ex)
            {
                // Log the exception here if you have logging
                return new StatusCodeResult(500);
            }
        }
    }
}
