using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TflDummyJsonRestApiTests.Models
{
    public class ProductResponse
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; } = new();
        public decimal Price { get; set; }
       // public int Count { get;  set; }
    }
}
