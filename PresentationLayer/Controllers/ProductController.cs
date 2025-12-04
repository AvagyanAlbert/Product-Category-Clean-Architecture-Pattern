using BusinessLogic.Interfaces;
using Domain.ProductDTOs;
using Microsoft.AspNetCore.Mvc;

namespace ProductCategory.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductController(IProductService service) => _service = service;

        [HttpPost]
        public async Task<ActionResult<int>> CreateProduct(CreateProductDTO createProductDTO)
        {
            var id = await _service.CreateProduct(createProductDTO);
            return CreatedAtAction(nameof(GetProductById), new { id }, id);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductById(int id)
        {
            var product= await _service.GetProductById(id);
            return Ok(product);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProductDTO>>> GetAllProductsPaged([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            pageNumber = Math.Max(pageNumber, 1);
            pageSize = Math.Clamp(pageSize, 1, 100);

            var product = await _service.GetProducts(pageNumber, pageSize);
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDTO updateProductDTO)
        {
            await _service.UpdateProduct(id, updateProductDTO);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _service.DeleteProduct(id);
            return NoContent();
        }
    }

}
