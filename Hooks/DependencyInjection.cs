using Reqnroll;
using Microsoft.Extensions.DependencyInjection;
using TflDummyJsonRestApiTests.Helpers;
using Reqnroll.Microsoft.Extensions.DependencyInjection;

namespace TflDummyJsonRestApiTests.Hooks
{
    [Binding]
    public sealed class DependencyInjection
    {
        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<TestContext>();

            return services;
        }
    }
}
