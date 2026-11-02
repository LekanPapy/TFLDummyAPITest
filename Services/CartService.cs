using RestSharp;
using Newtonsoft.Json;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Services
{
    public class CartService : BaseApiService
    {
        public async Task<AddCartResponse> AddCart(
       AddCartRequest payload)
        {
            var request =
                new RestRequest(
                    "/carts/add",
                    Method.Post);

            request.AddJsonBody(payload);

            var response = await SendAsync(request);
            return JsonConvert.DeserializeObject<AddCartResponse>(
                response.Content!)!;
        }

        public async Task<DeleteCartResponse> DeleteCart(
        int cartId)
        {
            var  request = new RestRequest(
                $"/carts/{cartId}",
                Method.Delete);
            var response = await SendAsync(request);

            return JsonConvert.DeserializeObject<DeleteCartResponse>(
                response.Content!)!;
        }

    }
}
