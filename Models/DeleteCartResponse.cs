
using Newtonsoft.Json;

namespace TflDummyJsonRestApiTests.Models
{
    public class DeleteCartResponse
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        [JsonProperty("deletedOn")]
        public string? DeletedOn { get; set; }
    }
}
