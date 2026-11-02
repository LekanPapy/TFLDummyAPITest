

using Newtonsoft.Json;

namespace TflDummyJsonRestApiTests.Models
{
    public class AuthenticatedUserResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("hairColor")]
        public string HairColor { get; set; }

       
    }
}
