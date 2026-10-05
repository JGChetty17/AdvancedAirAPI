using AdvancedAirAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace AdvancedAirAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_productService.GetAll());
        }

        // GET: api/products/samsung-inverter-12000
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            var product = _productService.GetById(id);
            if (product == null)
                return NotFound(new { message = $"Product '{id}' not found" });

            return Ok(product);
        }
    }
}