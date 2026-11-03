using RestSharp;
using Newtonsoft.Json;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Services
{
    public class AuthService : BaseApiService
    {
        public async Task<RestResponse> Login(LoginRequest loginRequest)
        {
            var request = new RestRequest(
                "/auth/login", Method.Post);

            request.AddJsonBody(loginRequest);
           
              return await SendAsync(request);
        }
        public async Task<RestResponse> GetCurrentUser(string token)
        {
            var request = new RestRequest("/auth/me", Method.Get);

            request.AddHeader(
                "Authorization",
                $"Bearer {token}");

            return await SendAsync(request);

        }
    }
}
