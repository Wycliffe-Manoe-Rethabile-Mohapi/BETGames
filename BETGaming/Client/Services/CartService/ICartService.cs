namespace BETGaming.Client.Services.CartService
{
    public interface ICartSrvice
    {
        event Action OnChange;

        Task<List<CartItem>> GetCartItemsAsync();

        Task AddCartItem(CartItem cartItem);

        Task<List<CartProductResponse>> GetCartProductsAsync();

        Task RemoveProductFromCart(int productId, int productTypeid);

        Task UpdateQuantity(CartProductResponse cartProductResponse);

        Task StoreCartItems(bool emptyLocalCart);
        Task<int> GetcartItemCount();
    }
}
