using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductMS.Models;

namespace ProductMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductDbContext _context;
        public ProductsController(ProductDbContext context)
        {
            _context = context;

        }
        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _context.Products.ToListAsync());
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _context.Products.FindAsync(id));

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return Content("Product Deleted");

            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(Product product)
        {
            await _context.Products.AddAsync(product);
          await  _context.SaveChangesAsync();
            return Ok (product);
        }
    }
}
