using BETGaming.Server.Data;
using System.Security.Claims;

namespace BETGaming.Server.Services.CartService
{
    public class CartService : ICartService
    {
        public DataContext _DataContext { get; }
        public IAuthService _AuthService { get; }

        public CartService(DataContext dataContext, IAuthService authService)
        {
            _DataContext = dataContext;
            _AuthService = authService;
        }

        

        public async Task<ServiceResponse<List<CartProductResponse>>> GetCartProductsAsync(List<CartItem> cartItems)
        {
            var result = new ServiceResponse<List<CartProductResponse>>
            {
                Data = new List<CartProductResponse>()
            };

            foreach (var item in cartItems)
            {
                var product = await _DataContext.Products.Where(s=>s.Id==item.ProductId).FirstOrDefaultAsync ();

                if (product==null)
                {
                    continue;
                }

                var productVariant = await _DataContext.ProductVariants
                        .Where(s=>s.ProductId==item.ProductId 
                                && s.ProductTypeId==item.ProductypeId)
                        .Include(s=>s.ProductType)
                        .FirstOrDefaultAsync ();

                if (productVariant==null)
                {
                    continue;
                }

                var cartProduct = new CartProductResponse()
                {
                    ProdictId = product.Id,
                    Title = product.Title,
                    ImageUrl = product.ImageURL,
                    Price = productVariant.Price,
                    ProductType = productVariant.ProductType.Name,
                    ProductTypeId = productVariant.ProductTypeId,
                    Quantity = item.Quantity
                };

                result.Data.Add(cartProduct);
            }

            return result;
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems)
        {
            var userId =_AuthService.GetUserId();

            foreach (var cartitem in cartItems)
            {
                cartitem.UserId = userId;
            }

            _DataContext.CartItems.AddRange(cartItems);

            await _DataContext.SaveChangesAsync();

            return await GetDatabaseCartProducts(null);
        }


        public async Task<ServiceResponse<int>> GetCartItemsCountAsync()
        {
            var count  =  _DataContext.CartItems.Count(s=>s.UserId==_AuthService.GetUserId());
            return new ServiceResponse<int>()
            {
                Data = count
            };
        }

        public async Task<ServiceResponse<List<CartProductResponse>>> GetDatabaseCartProducts(int? userId)
        {
            if(userId==null)
                userId = _AuthService.GetUserId();

            return await GetCartProductsAsync( _DataContext.CartItems.Where(s=>s.UserId== userId).ToList());
        }

        public async Task<ServiceResponse<bool>> AddToCart(CartItem cartItem)
        {
            cartItem.UserId= _AuthService.GetUserId();

            var dbcartItem = await  _DataContext.CartItems.FirstOrDefaultAsync(s => s.UserId == cartItem.UserId && s.ProductypeId == cartItem.ProductypeId && s.ProductId == cartItem.ProductId);
            if (dbcartItem == null)
            {
                _DataContext.CartItems.Add(cartItem);
            }
            else
            {
                dbcartItem.Quantity += cartItem.Quantity;
            }

            _DataContext.SaveChanges();

            return new ServiceResponse<bool>(){ Data=true};
        }

        public async Task<ServiceResponse<bool>> UpdateQuantity(CartItem cartItem)
        {
            cartItem.UserId = _AuthService.GetUserId();

            var dbcartItem = await _DataContext.CartItems.FirstOrDefaultAsync(s => s.UserId == cartItem.UserId && s.ProductypeId == cartItem.ProductypeId && s.ProductId == cartItem.ProductId);
            if (dbcartItem == null)
            {
                return new ServiceResponse<bool>() { Data = false ,Success=false,Message = "cart item does not exist"};
            }

            dbcartItem.Quantity = cartItem.Quantity;

            _DataContext.SaveChanges();

            return new ServiceResponse<bool>() { Data = true };
        }

        public async Task<ServiceResponse<bool>> RemoveCartItem(int productId, int productTypeId)
        {

            var dbcartItem = await _DataContext.CartItems.FirstOrDefaultAsync(s => s.UserId == _AuthService.GetUserId() && s.ProductypeId == productTypeId && s.ProductId == productId);

            if (dbcartItem == null)
            {
                return new ServiceResponse<bool>() { Data = false, Success = false, Message = "cart item does not exist" };
            }

            _DataContext.CartItems.Remove(dbcartItem);

            _DataContext.SaveChanges();

            return new ServiceResponse<bool>() { Data = true };
        }
    }
}
