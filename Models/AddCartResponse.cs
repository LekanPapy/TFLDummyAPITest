
using Newtonsoft.Json;

namespace TflDummyJsonRestApiTests.Models
{
    public class AddCartResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("total")]
        public decimal Total { get; set; }

        [JsonProperty("discountedTotal")]
        public decimal DiscountedTotal { get; set; }
        
        [JsonProperty("products")]
        public List<CartProductResponse> Products { get; set; }
            = new();
        
        [JsonProperty("totalQuantity")]
        public int TotalQuantity { get; set; }
    }
}
