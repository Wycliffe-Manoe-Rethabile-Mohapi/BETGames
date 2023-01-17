using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;

namespace BETGaming.Client
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        public ILocalStorageService _StorageService { get; }
        public HttpClient _HttpClient { get; }

        public CustomAuthStateProvider(ILocalStorageService storageService, HttpClient httpClient)
        {
            _StorageService = storageService;
            _HttpClient = httpClient;
        }

        

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var authToken = await _StorageService.GetItemAsStringAsync("authtoken");

            var ideityty = new ClaimsIdentity();
            _HttpClient.DefaultRequestHeaders.Authorization = null;

            if (!string.IsNullOrEmpty(authToken))
            {
                try
                {
                    ideityty = new ClaimsIdentity(ParseClaimsFromJwt(authToken), "jwt");
                    _HttpClient.DefaultRequestHeaders.Authorization =
                        new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", authToken.Replace("\"", ""));
                }
                catch (Exception ex)
                {
                    var x = ex.Message;
                    await _StorageService.RemoveItemAsync(authToken);
                    ideityty = new ClaimsIdentity();
                }
            }

            var user = new ClaimsPrincipal(ideityty);
            var state = new AuthenticationState(user);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }

        private byte[] ParseBase64WithoutPadding(string base64)
        {
            switch (base64.Length % 4)
            {
                case 2: base64 += "==";break;
                case 3: base64 += "="; break;
            }
            return Convert.FromBase64String(base64);
        }
        private IEnumerable<Claim>? ParseClaimsFromJwt(string jwt)
        {
            var payload = jwt.Split(".")[1];   
            var jsonBytes = ParseBase64WithoutPadding(payload);

            string jsonStr = Encoding.UTF8.GetString(jsonBytes);

            var keyValuePairs =
                 JsonConvert.DeserializeObject<Dictionary<String, Object>>(jsonStr);

            

            var claims = keyValuePairs.Select(
                kvp => new Claim(kvp.Key, kvp.Value.ToString()));

            return claims;  
        }
    }
}
