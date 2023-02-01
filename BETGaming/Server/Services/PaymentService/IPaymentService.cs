using Stripe.Checkout;

namespace BETGaming.Server.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Session> CreateCheckoutSession();

    }
}
