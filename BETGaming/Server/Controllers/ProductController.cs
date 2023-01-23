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
        public async Task<ActionResult<ServiceResponse<List<Product>>>> GetProducts()
        {
            var result = await _ProductService.GetProductsAsync();
            return Ok(result);
        }


        [HttpGet("{productId}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProduct(int productId)
        {
            var result = await _ProductService.GetProductAsync(productId);
            return Ok(result);
        }


        [HttpGet("category/{categoruUrl}")]
        public async Task<ActionResult<ServiceResponse<Product>>> GetProductByCategoryUrl(string categoruUrl)
        {
            var result = await _ProductService.GetProductsByCategoryAsync(categoruUrl);
            return Ok(result);
        }

        [HttpGet("search/{searchString}")]
        public async Task<ActionResult<ServiceResponse<List<Product>>>> SearchProductsAsync(string searchString)
        {
            var result = await _ProductService.SearchProductsAsync(searchString);
            return Ok(result);

        }

        [HttpGet("searchsuggestions/{searchString}")]
        public async Task<ActionResult<ServiceResponse<List<string>>>> GetProductSearchSuggestions(string searchString)
        {
            var result = await _ProductService.GetProductSearchSuggestions(searchString);
            return Ok(result);

        }
    }
}
