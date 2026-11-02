using RestSharp;
using Newtonsoft.Json;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Services
{
    public class AuthService : BaseApiService
    {
        public async Task<LoginResponse> Login(LoginRequest loginRequest)
        {
            var request = new RestRequest("/auth/login", Method.Post);

            request.AddJsonBody(new
            {
                username = loginRequest.Username,
                password = loginRequest.Password,
                expiresInMins = loginRequest.ExpiresInMins
            });

            var response = await SendAsync(request);

            return JsonConvert.DeserializeObject<LoginResponse>(
                response.Content!);

        }
        public async Task<AuthenticatedUserResponse> GetCurrentUser(string token)
        {
            var request = new RestRequest("/auth/me", Method.Get);

            request.AddHeader(
                "Authorization",
                $"Bearer {token}");

            var response = await SendAsync(request);

            return JsonConvert.DeserializeObject<AuthenticatedUserResponse>(
                response.Content!)!;
        }
    }
}
