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

        [HttpPost]
        public IActionResult ProcessProducts([FromBody] List<InputView> input)
        {
            try
            {
                var result = _productService.ProcessProducts(input);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
