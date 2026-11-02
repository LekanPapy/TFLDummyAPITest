using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TflDummyJsonRestApiTests.Models
{
    public class CartProductRequest
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        
        [JsonProperty("quantity")]
        public int Quantity { get; set; }
    }
}
