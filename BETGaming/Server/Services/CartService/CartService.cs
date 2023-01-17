using BETGaming.Server.Data;

namespace BETGaming.Server.Services.CartService
{
    public class CartService : ICartService
    {
        public DataContext _DataContext { get; }
        public CartService(DataContext dataContext)
        {
            _DataContext = dataContext;
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
                    ProductTypeId = productVariant.ProductTypeId
                };

                result.Data.Add(cartProduct);
            }

            return result;
        }
    }
}
