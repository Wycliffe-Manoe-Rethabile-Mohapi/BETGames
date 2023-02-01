using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BETGaming.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        public IPaymentService _PaymentService { get; }
        public PaymentController(IPaymentService paymentService)
        {
            _PaymentService = paymentService;
        }

        [HttpPost("checkout"),Authorize]
        public async Task<ActionResult<string>> CreateCheckoutSession()
        {
            var session = await _PaymentService.CreateCheckoutSession();
            return Ok(session.Url);
        }
    }
}
