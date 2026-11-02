using Newtonsoft.Json;
using RestSharp;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Services
{
    public class UserService : BaseApiService
    {
        public async Task<UserResponse> GetAllUsers()
        {
            var request =
            new RestRequest(
                "/users?limit=0",
                Method.Get);

            var response =
                await SendAsync(request);

            return JsonConvert.DeserializeObject<UserResponse>(
                response.Content!)!;
        }

        public async Task<AddUserResponse> AddUser(
            AddUserRequest payload)
        {
            var request =
                new RestRequest(
                    "/users/add",
                    Method.Post);

            request.AddJsonBody(payload);
            var response = await SendAsync(request);

            return JsonConvert.DeserializeObject<AddUserResponse>(
        response.Content!)!;
        }
    }
}
