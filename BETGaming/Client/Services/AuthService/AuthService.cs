using BETGaming.Shared;
using Remotion.Linq.Clauses.ResultOperators;

namespace BETGaming.Client.Services.AuthService
{
    public class AuthService : IAuthService
    {
        public HttpClient _HttpClient { get; }
        public AuthService(HttpClient httpClient)
        {
            _HttpClient = httpClient;
        }


        public async Task<ServiceResponse<int>> Register(UserRegister userRegister)
        {
            var response = await _HttpClient.PostAsJsonAsync("api/auth/register", userRegister);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<int>>();
        }

        public async Task<ServiceResponse<string>> Login(UserLogin userLogin)
        {
            var response = await _HttpClient.PostAsJsonAsync("api/auth/login", userLogin);
            return  await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
        }

        public async Task<ServiceResponse<bool>> ChangePassword(UserChangePassword userChangePassword)
        {
            var response = await _HttpClient.PostAsJsonAsync("api/auth/change-password", userChangePassword.Password);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
        }
    }
}
