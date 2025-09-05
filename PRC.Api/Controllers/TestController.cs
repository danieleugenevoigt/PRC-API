using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PRC.Core;

namespace PRC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly AppDbContext _context;
        
        public TestController(AppDbContext context)
        {
            _context = context;
        }
        
        [HttpGet("products-simple")]
        public async Task<IActionResult> GetProductsSimple()
        {
            try
            {
                var products = await _context.Products.Take(5).ToListAsync();
                return Ok(products.Select(p => new { 
                    p.Id, 
                    p.Title, 
                    p.Sku 
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message, StackTrace = ex.StackTrace });
            }
        }
        
        [HttpGet("product-images")]
        public async Task<IActionResult> GetProductImages()
        {
            try
            {
                var images = await _context.ProductImages.Take(5).ToListAsync();
                return Ok(images);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message, StackTrace = ex.StackTrace });
            }
        }
        
        [HttpGet("products-with-images")]
        public async Task<IActionResult> GetProductsWithImages()
        {
            try
            {
                var products = await _context.Products
                    .Include(p => p.ProductImages)
                    .Take(1)
                    .ToListAsync();
                    
                return Ok(products.Select(p => new { 
                    p.Id, 
                    p.Title, 
                    p.Sku,
                    ImageCount = p.ProductImages.Count,
                    Images = p.ProductImages.Select(img => new {
                        img.Id,
                        img.ImageUrl,
                        img.SortOrder
                    })
                }));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message, StackTrace = ex.StackTrace });
            }
        }
    }
}
