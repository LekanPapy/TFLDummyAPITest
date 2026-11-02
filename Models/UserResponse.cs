using Newtonsoft.Json;

namespace TflDummyJsonRestApiTests.Models
{
    public class UserResponse
    {
        [JsonProperty("users")]
        public List<User> Users { get; set; } = new();

        [JsonProperty("total")]
        public int Total { get; set;}
    }
}
