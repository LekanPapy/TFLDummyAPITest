using Reqnroll;
using TflDummyJsonRestApiTests.Services;
using TflDummyJsonRestApiTests.Helpers;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Hooks
{
    [Binding]
    public class AuthHooks
    {
        private readonly TestContext _testContext;
    private readonly AuthService _authService;

    public AuthHooks(TestContext testContext)
    {
        _testContext = testContext;
        _authService = new AuthService();
    }

        [BeforeScenario("@auth")]
        public async Task AuthenticateUser()
        {
            var authSettings =
        ConfigurationHelper.AuthSettings;

            var request = new LoginRequest
            {
                Username = authSettings.Username,
                Password = authSettings.Password,
                ExpiresInMins = authSettings.ExpiresInMins
            };

            var response =
                  await _authService.Login(request);

            var loginResponse =
                ResponseHelper.Parse<LoginResponse>(response);

            _testContext.AccessToken =
                loginResponse.AccessToken;

            _testContext.LoginResponse =
                loginResponse;
        }
    }
}
