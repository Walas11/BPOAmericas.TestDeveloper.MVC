using BPOAmericas.TestDeveloper.MVC.Models.Login;
using System.Text;

namespace BPOAmericas.TestDeveloper.MVC.Services.Auth
{
    public class AuthService
    {
        private readonly HttpClient _httpClient;

        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<(LoginApiResponse response, string token)> LoginAsync(string email, string password, string clientIp, string userAgent)
        {
            var request = new LoginApiRequest
            {
                UserName = Convert.ToBase64String(Encoding.UTF8.GetBytes(email)),
                UserPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password)),
                ClientIP = clientIp,
                UserAgent = userAgent
            };

            var httpResponse = await _httpClient.PostAsJsonAsync("Security/LoginUser", request);

            if (!httpResponse.IsSuccessStatusCode)
                return (null, null);

            var loginResponse = await httpResponse.Content.ReadFromJsonAsync<LoginApiResponse>();

            string token = null;
            if (httpResponse.Headers.TryGetValues("Authorization", out var values))
                token = values.FirstOrDefault();

            return (loginResponse, token);
        }
    }
}
