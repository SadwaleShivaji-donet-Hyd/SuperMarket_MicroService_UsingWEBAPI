using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderMS.Models;

namespace OrderMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderDbContext _context;
        private readonly HttpClient _client;
        public OrdersController(OrderDbContext context, IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(int ProductId, int quantity)
        {
            try
            {
                var product = await _client.GetFromJsonAsync<Product>($"http://localhost:5091/api/Products/{ProductId}");

                if (product == null) { return NotFound("Product Not Found"); }
                var total = product.Price * quantity;
                var orders = new Order { ProductId = ProductId, ProductName = product.Name, Category = product.Category, Quantity = quantity, Price = product.Price, TotalAmount = total };
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return Ok(orders);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            var products = await _client.GetFromJsonAsync<IEnumerable<Product>>($"http://localhost:5173/Products");
            return Ok(products);
        }
    }
}
