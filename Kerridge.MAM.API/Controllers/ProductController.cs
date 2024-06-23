using Kerridge.MAM.Data.Models;
using Kerridge.MAM.Services.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kerridge.MAM.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var allProducts = await _productService.GetAllProductsAsync();

            return Ok(allProducts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProductById(id);

            if(product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]//(Name = "AddProduct")]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }

        [HttpPut]//(Name = "UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if(id != product.ProductId)
            {
                return BadRequest();
            }

            await _productService.UpdateProduct(product);
            return NoContent();
        }

        [HttpDelete("{id}")] //(Name = "DeleteProduct")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
