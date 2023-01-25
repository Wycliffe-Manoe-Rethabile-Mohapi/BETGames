using BETGaming.Server.Data;
using System.Security.Claims;

namespace BETGaming.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public OrderService(DataContext dataContext, IHttpContextAccessor httpContextAccessor, ICartService cartService)
        {
            _DataContext = dataContext;
            _HttpContextAccessor = httpContextAccessor;
            _CartService = cartService;
        }

        public DataContext _DataContext { get; }
        public IHttpContextAccessor _HttpContextAccessor { get; }
        public ICartService _CartService { get; }

        private int GetUserId() => int.Parse(_HttpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));

        public async Task<ServiceResponse<bool>> PlaceOrder()
        {
            var products = (await _CartService.GetDatabaseCartProducts()).Data;

            decimal totalPrice = products.Sum(s=>s.Price*s.Quantity);

            var orderItems = new List<OrderItem>();
            products.ForEach(
                s=> orderItems.Add(
                    new OrderItem()
                    {
                        ProductId=s.ProdictId,
                        ProductTypeId=s.ProductTypeId,
                        Quantity=s.Quantity,
                        TotalPrice = s.Price * s.Quantity
                    }
                    )
                );

            var order = new Order()
            {
                UserId= GetUserId(),
                OrderDate = DateTime.Now,
                OrderItems = orderItems,
                TotalPrice= totalPrice,
            };

            _DataContext.Orders.Add( order );
            _DataContext.SaveChangesAsync();

            return new ServiceResponse<bool>() { Data = true };
        }
    }
}
