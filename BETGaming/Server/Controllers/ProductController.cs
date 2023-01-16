using BETGaming.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETGaming.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;

        public ProductController(DataContext dataContext)
        {
            this._context = dataContext;
        }


        [HttpGet]
        public  async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            var response = new ServiceResponse<List<Product>>() { };
            response.Data = products;
            return  Ok(response);
        }
    }
}
