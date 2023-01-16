using BETGaming.Server.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETGaming.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _ProductService;

        public ProductController(IProductService ProductService)
        {
            this._ProductService = ProductService;
        }


        [HttpGet]
        public  async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _ProductService.GetProductsAsync();
            return  Ok(result);
        }
    }
}
