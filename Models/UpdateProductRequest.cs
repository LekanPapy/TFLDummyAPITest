using Newtonsoft.Json;

namespace TflDummyJsonRestApiTests.Models
{
    public class UpdateProductRequest
    {
        [JsonProperty("title")]
        public string Title { get; set; }   
    }
}
