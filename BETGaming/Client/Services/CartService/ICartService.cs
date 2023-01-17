namespace BETGaming.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;

        Task<List<CartItem>> GetCartItemsAsync();

        Task AddCartItem(CartItem cartItem);

        Task<List<CartProductResponse>> GetCartProductsAsync();
    }
}
