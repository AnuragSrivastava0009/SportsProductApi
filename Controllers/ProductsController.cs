using Microsoft.AspNetCore.Mvc;
using SportsProductApi.DTO;
using SportsProductApi.Interfaces;
using SportsProductApi.Models;

namespace SportsProductApi.Controllers
{
    // Controller
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service) => _service = service;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductCreateDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                StockAvailable = dto.StockAvailable,
                Description = dto.Description,
                Category = dto.Category,
                Brand = dto.Brand,
                Player = dto.Player
            };

            var created = await _service.CreateProductAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = created.ProductId }, created);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllProductsAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var product = await _service.GetProductByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var deleted = await _service.DeleteProductAsync(id);
            return deleted ? Ok() : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, [FromBody] Product updated)
        {
            var result = await _service.UpdateProductAsync(id, updated);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpPut("decrement-stock/{id}/{quantity}")]
        public async Task<IActionResult> DecrementStock(string id, int quantity)
        {
            var result = await _service.DecrementStockAsync(id, quantity);
            return result == null ? BadRequest("Invalid stock decrement request") : Ok(result);
        }

        [HttpPut("add-to-stock/{id}/{quantity}")]
        public async Task<IActionResult> AddToStock(string id, int quantity)
        {
            var result = await _service.AddToStockAsync(id, quantity);
            return result == null ? NotFound() : Ok(result);
        }
    }
}
