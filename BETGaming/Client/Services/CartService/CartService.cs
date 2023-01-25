using BETGaming.Shared;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;

namespace BETGaming.Client.Services.CartService
{
    public class CartService : ICartSrvice
    {
        public ILocalStorageService _LocalStorage { get; }
        public HttpClient _HttpClient { get; }
        public AuthenticationStateProvider _AuthenticationStateProvider { get; }

        public event Action OnChange;

        public CartService(ILocalStorageService LocalStorage, HttpClient httpClient,
            AuthenticationStateProvider authenticationStateProvider)
        {
            this._LocalStorage = LocalStorage;
            _HttpClient = httpClient;
            _AuthenticationStateProvider = authenticationStateProvider;
        }

        

        public async Task AddCartItem(CartItem cartItem)
        {
            if (await IsUserAuthenticated())
            {
                Console.WriteLine("Authenticated");
            }
            else
            {
                Console.WriteLine("not authenticated");
            }

            var cart = await _LocalStorage.GetItemAsync<List<CartItem>>("cart");
            if (cart == null)
            {
                cart = new List<CartItem>();

            }

            var sameItem = cart.Find(s => s.ProductId == cartItem.ProductId && s.ProductypeId == cartItem.ProductypeId);

            if (sameItem == null)
            {
                cart.Add(cartItem);
            }
            else
            {
                sameItem.Quantity += cartItem.Quantity;
            }

            await _LocalStorage.SetItemAsync("cart", cart);

            await GetCartItemCount();
        }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }


        public async Task<List<CartProductResponse>> GetCartProductsAsync()
        {
            if (await IsUserAuthenticated())
            {
                var response = await _HttpClient.GetFromJsonAsync<ServiceResponse<List<CartProductResponse>>>("api/cart");
                return response.Data;
            }
            else
            {
                var cartitems = await _LocalStorage.GetItemAsync<List<CartItem>>("cart");
                if (cartitems == null)
                    return new List<CartProductResponse>();

                var response = await _HttpClient.PostAsJsonAsync("api/cart/products", cartitems);
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<CartProductResponse>>>();

                return result.Data;
            }
            
            
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

                await GetCartItemCount();
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

        public async Task StoreCartItems(bool emptyLocalCart=false)
        {
            var localCart = await _LocalStorage.GetItemAsync<List<CartItem>>("cart");
            if (localCart == null)
            {
                return;
            }


             await _HttpClient.PostAsJsonAsync("api/cart", localCart);

            if (emptyLocalCart)
            {
                await _LocalStorage.RemoveItemAsync("cart");
            }
        }

        public async Task GetCartItemCount()
        {
            if (await IsUserAuthenticated())
            {
                var result = await _HttpClient.GetFromJsonAsync<ServiceResponse<int>>("api/cart/count");
                var count = result.Data;

                await _LocalStorage.SetItemAsync<int>("cartItemsCount", count);
            }
            else
            {
                var localCart = await _LocalStorage.GetItemAsync<List<CartItem>>("cart");
                await _LocalStorage.SetItemAsync<int>("cartItemsCount", localCart != null? localCart.Count:0);
            }

            if (OnChange != null)
            {
                OnChange.Invoke();
            }
        }
    }
}
