
using Newtonsoft.Json;

namespace TflDummyJsonRestApiTests.Models
{
    public class LoginRequest
    {
        [JsonProperty("username")]
        public string Username { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        [JsonProperty("expiresInMins")]
        public int ExpiresInMins { get; set; }
    }
}
