namespace BETGaming.Server.Services.CartService
{
    public interface ICartService
    {
        Task<ServiceResponse<List<CartProductResponse>>> GetCartProductsAsync(List<CartItem> cartItems);
        Task<ServiceResponse<List<CartProductResponse>>> StoreCartItems(List<CartItem> cartItems);
        Task<ServiceResponse<int>> GetCartItemsCountAsync();
    }
}
