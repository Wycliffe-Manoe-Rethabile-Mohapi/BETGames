using BETGaming.Shared;
using Blazored.LocalStorage;

namespace BETGaming.Client.Services.CartService
{
    public class CartService : ICartService
    {
        public ILocalStorageService _LocalStorage { get; }
        public HttpClient _HttpClient { get; }

        public event Action OnChange;

        public CartService(ILocalStorageService LocalStorage, HttpClient httpClient)
        {
            this._LocalStorage = LocalStorage;
            _HttpClient = httpClient;
        }

        

        public async Task AddCartItem(CartItem cartItem)
        {
            var cart = await _LocalStorage.GetItemAsync<List<CartItem>> ("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();

            }

            var sameItem = cart.Find(s=>s.ProductId==cartItem.ProductId && s.ProductypeId==cartItem.ProductypeId);

            if (sameItem==null)
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity+= cartItem.Quantity;
            }

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

        public async Task<List<CartProductResponse>> GetCartProductsAsync()
        {
            var cartitems = await GetCartItemsAsync();
            var response = await _HttpClient.PostAsJsonAsync("api/cart/products", cartitems);
            var result   =  await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();

            return result.Data;
        }

        public async Task RemoveProductFromCart(int productId, int productTypeid)
        {
            var cart = await _LocalStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart==null)
            {
                return;
            }

            var cartItem = cart.Find(s => s.ProductId == productId && s.ProductypeId == productTypeid);
            if (cartItem!=null)
            {
                cart.Remove(cartItem);

                await _LocalStorage.SetItemAsync("cart", cart);

                if (OnChange != null)
                {
                    OnChange.Invoke();
                }
            }
            
        }

        public async Task UpdateQuantity(CartProductResponse product)
        {
            var cart = await _LocalStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                return;
            }

            var cartItem = cart.Find(s => s.ProductId == product.ProdictId && s.ProductypeId == product.ProductTypeId);
            if (cartItem != null)
            {
                cartItem.Quantity = product.Quantity;

                await _LocalStorage.SetItemAsync("cart", cart);

            }
        }
    }
}
