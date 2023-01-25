using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETGaming.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public OrderController(IOrderService OrderServiuce)
        {
            this._OrderServiuce = OrderServiuce;
        }

        public IOrderService _OrderServiuce { get; }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<bool>>> PlaceOrder()
        {
            var result = await _OrderServiuce.PlaceOrder();
            return Ok(result);
        }
    }
}
