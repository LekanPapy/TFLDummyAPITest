using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TflDummyJsonRestApiTests.Reporting
{
    public static class ApiReportLogger
    {
        public static void LogRequest(
        RestRequest request)
        {
            Console.WriteLine(
                $"REQUEST: {request.Resource}");
        }

        public static void LogResponse(
            RestResponse response)
        {
            Console.WriteLine(
                $"STATUS: {response.StatusCode}");

            Console.WriteLine(
                response.Content);
        }

    }
}
