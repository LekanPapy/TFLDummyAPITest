using Newtonsoft.Json;
using RestSharp;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Services
{
    public class ProductsService : BaseApiService
    {
        public async Task<RestResponse> SearchProduct(string productName)
        {
           var request = new RestRequest(
                  $"/products/search?q={productName}",
                    Method.Get);

            return await SendAsync(request);

        }

        public async Task<RestResponse> GetFifteenthProduct()
        {
            var request = new RestRequest(
                "/products?limit=1&skip=14",
                    Method.Get);
            return await SendAsync (request);

  
        }
        public async Task<RestResponse>UpdateProduct(int productId,UpdateProductRequest requestBody)
        {
            var request =
                new RestRequest(
                    $"/products/{productId}",
                    Method.Put);

            request.AddJsonBody(requestBody);

            return await SendAsync(request);
          
        }
    }
}
