namespace BETGaming.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public HttpClient _HttpClient { get; }
        public AuthService(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public HttpClient HttpClient { get; }

        public async Task<ServiceResponse<int>> Register(UserRegister userRegister)
        {
            var response = await _HttpClient.PostAsJsonAsync("api/auth/register", userRegister);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }
    }
}
