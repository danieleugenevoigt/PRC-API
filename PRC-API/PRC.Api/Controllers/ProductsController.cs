using Microsoft.AspNetCore.Mvc;
using PRC.Api.Handlers;

namespace PRC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductHandler _productHandler;
        
        public ProductsController(ProductHandler productHandler)
        {
            _productHandler = productHandler;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            return await _productHandler.GetAllProductsAsync();
        }
        
        [HttpGet("{id:long}")]
        public async Task<IActionResult> GetProduct(long id)
        {
            return await _productHandler.GetProductByIdAsync(id);
        }
        
        [HttpGet("sku/{sku}")]
        public async Task<IActionResult> GetProductBySku(string sku)
        {
            return await _productHandler.GetProductBySkuAsync(sku);
        }
        
        [HttpGet("active")]
        public async Task<IActionResult> GetActiveProducts()
        {
            return await _productHandler.GetActiveProductsAsync();
        }
    }
}


