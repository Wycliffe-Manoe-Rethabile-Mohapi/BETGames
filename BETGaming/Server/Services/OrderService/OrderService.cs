﻿using BETGaming.Server.Data;
using System.Security.Claims;

namespace BETGaming.Server.Services.OrderService
{
    public class OrderService : IOrderService
    {
        public OrderService(DataContext dataContext, IAuthService authService, ICartService cartService)
        {
            _DataContext = dataContext;
            _AuthService = authService;
            _CartService = cartService;
        }

        public DataContext _DataContext { get; }
        public IAuthService _AuthService { get; }
        public ICartService _CartService { get; }

        public async Task<ServiceResponse<List<OrderOverviewResponse>>> GetOrders()
        {
            var response = new ServiceResponse<List<OrderOverviewResponse>>();

            var orders =  await  _DataContext.Orders
                            .Include(s=>s.OrderItems)
                            .ThenInclude(s=>s.Product)
                            .Where(s=>s.UserId == _AuthService.GetUserId())
                            .OrderByDescending(s=>s.OrderDate)
                            .ToListAsync();

            var orderviewresponse = new List<OrderOverviewResponse>();

            orders.ForEach(s=> orderviewresponse.Add(new OrderOverviewResponse
            {
                Id = s.Id,
                OrderDate= s.OrderDate,
                Totalprice = s.TotalPrice,
                Product = s.OrderItems.Count > 1 ?
                    $"{s.OrderItems.First().Product.Title} and" +
                    $"{s.OrderItems.Count-1} more...":
                    s.OrderItems.First().Product.Title,
                ProductImageUrl = s.OrderItems.First().Product.ImageURL
            }));
            response.Data = orderviewresponse;
            return response; 
        }

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
                UserId= _AuthService.GetUserId(),
                OrderDate = DateTime.Now,
                OrderItems = orderItems,
                TotalPrice= totalPrice,
            };

            _DataContext.Orders.Add( order );

            _DataContext.CartItems.RemoveRange(_DataContext.CartItems.Where(s=>s.UserId==_AuthService.GetUserId()));

            await _DataContext.SaveChangesAsync();

            return new ServiceResponse<bool>() { Data = true };
        }
    }
}