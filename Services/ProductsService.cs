using Newtonsoft.Json;
using RestSharp;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Services
{
    public class ProductsService : BaseApiService
    {
        public async Task<ProductResponse> SearchProduct(string productName)
        {
           var request = new RestRequest(
                  $"/products/search?q={productName}",
                    Method.Get);

            var response = await SendAsync(request);

            return JsonConvert.DeserializeObject<ProductResponse>(
                response.Content!)!;
        }

        public async Task<ProductResponse> GetFifteenthProduct()
        {
            var request = new RestRequest(
                "/products?limit=1&skip=14",
                    Method.Get);
            var response = await SendAsync(request);

            return JsonConvert.DeserializeObject<ProductResponse>(
                response.Content!)!;
        }
        public async Task<Product>UpdateProduct(int productId,UpdateProductRequest requestBody)
        {
            var request =
                new RestRequest(
                    $"/products/{productId}",
                    Method.Put);

            request.AddJsonBody(requestBody);

            var response = await SendAsync(request);
          

            return JsonConvert.DeserializeObject<Product>(
                response.Content!)!;
        }
    }
}
