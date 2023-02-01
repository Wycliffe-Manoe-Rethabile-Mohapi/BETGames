using BETGaming.Server.Migrations;
using BETGaming.Server.Services.CartService;
using BETGaming.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> StoreCartItems(List<CartItem> cartItems)
        {
            var result = await CartService.StoreCartItems(cartItems);
            return Ok(result);
        }

        [HttpGet("count")]
        public async Task<ActionResult<ServiceResponse<int>>> GetCartCount()
        {
            var result = await CartService.GetCartItemsCountAsync();
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<CartProductResponse>>>> GetDatabaseProducts()
        {
            var result = await CartService.GetDatabaseCartProducts(null);
            return Ok(result);
        }

        [HttpPost("add")]
        public async Task<ActionResult<ServiceResponse<bool>>> AddToCart(CartItem cartitem)
        {
            var result = await CartService.AddToCart(cartitem);
            return Ok(result);
        }

        [HttpPut("update-quantity")]
        public async Task<ActionResult<ServiceResponse<bool>>> UpdateQuantity(CartItem cartitem)
        {
            var result = await CartService.UpdateQuantity(cartitem);
            return Ok(result);
        }

        [HttpDelete("{productId}/{productTypeId}")]
        public async Task<ActionResult<ServiceResponse<bool>>> RemoveCartItem(int productId, int productTypeId)
        {
            var result = await CartService.RemoveCartItem(productId, productTypeId);
            return Ok(result);
        }
    }
}
