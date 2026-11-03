using FluentAssertions;
using RestSharp;
using System;
using System.Net;


namespace TflDummyJsonRestApiTests.Helpers
{
    public static class ApiAssertions
    { 
        public static void AssertSuccess(RestResponse response)
        {
            response.IsSuccessful.Should()
           .BeTrue();
        }

        public static void AssertOk(
        RestResponse response)
        {
            response.StatusCode.Should()
                .Be(HttpStatusCode.OK);
        }

        public static void AssertCreated(RestResponse response)
        {
            response.StatusCode.Should()
            .Be(HttpStatusCode.Created);
        }

    }
}
