
using Newtonsoft.Json;

namespace TflDummyJsonRestApiTests.Models
{
    public class AddCartRequest
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }
        
        [JsonProperty("products")]
        public List<CartProductRequest> Products { get; set; }
            = new();
    }
}
