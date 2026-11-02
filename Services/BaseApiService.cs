using RestSharp;
using TflDummyJsonRestApiTests.Helpers;

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
            return await Client.ExecuteAsync(request);
        }
    }
}
