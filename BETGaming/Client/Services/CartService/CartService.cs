using Blazored.LocalStorage;

namespace BETGaming.Client.Services.CartService
{
    public class CartService : ICartService
    {
        public ILocalStorageService _LocalStorage { get; }

        public event Action OnChange;

        public CartService(ILocalStorageService LocalStorage)
        {
            this._LocalStorage = LocalStorage;
        }

        

        public async Task AddCartItem(CartItem cartItem)
        {
            var cart = await _LocalStorage.GetItemAsync<List<CartItem>> ("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();

            }

            cart.Add (cartItem);

            await _LocalStorage.SetItemAsync("cart", cart);

            if (OnChange!=null)
            {
                OnChange.Invoke();
            }
        }

        public async Task<List<CartItem>> GetCartItemsAsync()
        {
            var cart = await _LocalStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();

            }
            return cart;
        }
    }
}
