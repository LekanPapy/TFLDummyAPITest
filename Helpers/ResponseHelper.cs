using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TflDummyJsonRestApiTests.Helpers
{
    public static class ResponseHelper
    {
        public static T Parse<T>(RestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content!)!;
        }
    }
}
