using RestSharp;
using TflDummyJsonRestApiTests.Helpers;
using TflDummyJsonRestApiTests.Reporting;

namespace TflDummyJsonRestApiTests.Services
{
    public abstract class BaseApiService
    {
        protected readonly RestClient Client;
        public BaseApiService()
        {
            Client = new RestClient(
                ConfigurationHelper.BaseUrl);
        }

        protected async Task<RestResponse> SendAsync(RestRequest request)
        {
            ApiReportLogger.LogRequest(request);

            var response = await Client.ExecuteAsync(request);

            ApiReportLogger.LogResponse(response);

            return response;
        }
    }
}
