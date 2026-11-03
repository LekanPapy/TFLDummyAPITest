using RestSharp;
using Newtonsoft.Json;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Services
{
    public class CartService : BaseApiService
    {
        public async Task<RestResponse> AddCart(
       AddCartRequest payload)
        {
            var request =
                new RestRequest(
                    "/carts/add",
                    Method.Post);

            request.AddJsonBody(payload);

            return await SendAsync(request);
        }

        public async Task<RestResponse> DeleteCart(
        int cartId)
        {
            var  request = new RestRequest(
                $"/carts/{cartId}",
                Method.Delete);
            return await SendAsync(request);

           
        }

    }
}
