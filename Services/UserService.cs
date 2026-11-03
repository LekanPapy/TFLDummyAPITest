using Newtonsoft.Json;
using RestSharp;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Services
{
    public class UserService : BaseApiService
    {
        public async Task<RestResponse> GetAllUsers()
        {
            var request =
            new RestRequest(
                "/users?limit=0",
                Method.Get);

            var response =
                await SendAsync(request);

            return response;
        }

        public async Task<RestResponse> AddUser(
            AddUserRequest payload)
        {
            var request =
                new RestRequest(
                    "/users/add",
                    Method.Post);

            request.AddJsonBody(payload);

            return await SendAsync(request);

        }
            
    }
}
