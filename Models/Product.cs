using Newtonsoft.Json;

namespace TflDummyJsonRestApiTests.Models
{
    public class Product
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("price")]
        public decimal Price { get; set; }
    }
}
