namespace BETGaming.Client.Services.CartService
{
    public interface ICartService
    {
        event Action OnChange;

        Task<List<CartItem>> GetCartItemsAsync();

        Task AddCartItem(CartItem cartItem);

        Task<List<CartProductResponse>> GetCartProductsAsync();

        Task RemoveProductFromCart(int productId, int productTypeid);

        Task UpdateQuantity(CartProductResponse cartProductResponse);
    }
}
