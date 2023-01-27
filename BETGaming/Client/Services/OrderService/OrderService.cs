using Microsoft.AspNetCore.Components;
using System.Collections.Generic;

namespace BETGaming.Client.Services.OrderService
{
    public class OrderService:IOrderService
    {
        public OrderService(HttpClient httpClient, AuthenticationStateProvider authenticationStateProvider, NavigationManager navigationManager)
        {
            _HttpClient = httpClient;
            _AuthenticationStateProvider = authenticationStateProvider;
            _NavigationManager = navigationManager;
        }

        public HttpClient _HttpClient { get; }
        public AuthenticationStateProvider _AuthenticationStateProvider { get; }
        public NavigationManager _NavigationManager { get; }

        private async Task<bool> IsUserAuthenticated()
        {
            return (await _AuthenticationStateProvider.GetAuthenticationStateAsync()).User.Identity.IsAuthenticated;
        }

        public async Task PlaceOrder()
        {
            if (await IsUserAuthenticated())
            {
                 await _HttpClient.PostAsync("api/order/",null);
            }
            else
            {
                _NavigationManager.NavigateTo("login");
            }
            
        }

        public async Task<List<OrderOverviewResponse>> GetOrders()
        {
            var result = await _HttpClient.GetFromJsonAsync<ServiceResponse<List<OrderOverviewResponse>>>("api/order");
            return result.Data;
        }
    }
}
