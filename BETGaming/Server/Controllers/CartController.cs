using BETGaming.Server.Services.CartService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ICartService = BETGaming.Server.Services.CartService.ICartService;

namespace BETGaming.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        public ICartService CartService { get; }
        public CartController(ICartService cartService)
        {
            CartService = cartService;
        }

        

        [HttpPost("products")]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetCartProducts(List<CartItem> cartItems)
        {
            var result = await CartService.GetCartProductsAsync(cartItems);
            return Ok(result);
        }
    }
}
