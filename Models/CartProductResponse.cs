
using Newtonsoft.Json;

namespace TflDummyJsonRestApiTests.Models
{
    public class CartProductResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty ("title")] 
        public string Title { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
        
        [JsonProperty("discountPercentage")]
        public decimal DiscountPercentage { get; set; }
        
        [JsonProperty("discountedTotal")]
        public decimal DiscountedTotal { get; set; }

        [JsonProperty("quantity")]  
        public int Quantity { get; set; }
    }
}
