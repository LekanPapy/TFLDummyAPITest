using Newtonsoft.Json;
using RestSharp;

namespace TflDummyJsonRestApiTests.Models
{
    public class AddUserResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("firstName")]
        public string FirstName { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("age")]
        public int Age { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("hair")]
        public Hair Hair { get; set; }

        [JsonProperty("address")]
        public Address Address { get; set; }

    }
}
