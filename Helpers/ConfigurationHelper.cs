using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using TflDummyJsonRestApiTests.Configuration;

namespace TflDummyJsonRestApiTests.Helpers
{
    public static class ConfigurationHelper
    {
        private static readonly IConfiguration Configuration =
        new ConfigurationBuilder()
             .AddJsonFile(
                "appsettings.json",
                optional: false,
                reloadOnChange: true)
            .Build();
        public static string BaseUrl =>
        Configuration["BaseUrl"];

        public static AuthSettings AuthSettings =>
            Configuration.GetSection("AuthSettings")
                .Get<AuthSettings>()!;
    //    public static LoginRequest AuthSettings =>
    //        Configuration.GetSection("AuthSettings")
    //            .Get<LoginRequest>();
    //
    //
    }
}
