using Stripe;
using Stripe.Checkout;

namespace BETGaming.Server.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        public ICartService _CartService { get; }
        public IAuthService _AuthService { get; }
        public IOrderService _OrderService { get; }

        public PaymentService( ICartService cartService,
                    IAuthService authService,
                    IOrderService orderService)
        {
            StripeConfiguration.ApiKey = "sk_test_51MWcC5CMiQ9pOJ5yhR4jiA0UwuY9ZJV2dRLxNtiAXjIchyZT10tM6UPROY53g7xNndQy60apxukzwwFjdJGnvMBf00OQxPZTQj";
            _CartService = cartService;
            _AuthService = authService;
            _OrderService = orderService;
        }

        

        public async Task<Session> CreateCheckoutSession()
        {
            var products = (await _CartService.GetDatabaseCartProducts()).Data;
            var lineItems = new List<SessionLineItemOptions>();

            foreach (var product in products)
            {
                var item = new SessionLineItemOptions()
                {
                    PriceData = new SessionLineItemPriceDataOptions()
                    {
                        Currency="zar",
                        UnitAmountDecimal = product.Price*100,
                        ProductData = new SessionLineItemPriceDataProductDataOptions()
                        {
                            Name = product.Title,
                            Description=product.ProductType,
                            Images = new List<string>() { product.ImageUrl}
                        }
                    },
                    Quantity = product.Quantity
                };

                lineItems.Add(item);
            }
        }
    }
}
