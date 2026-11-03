using FluentAssertions;
using Newtonsoft.Json;
using Reqnroll;
using RestSharp;

using TflDummyJsonRestApiTests.Helpers;
using TflDummyJsonRestApiTests.Models;
using TflDummyJsonRestApiTests.Services;

namespace TflDummyJsonRestApiTests.StepDefinitions
{
    [Binding]
    public class AuthenticationStepDefinitions

    {
        private readonly TestContext _testContext;
        private readonly AuthService _authService;

        public AuthenticationStepDefinitions(
            TestContext testContext)
        {
            _testContext = testContext;
            _authService = new AuthService();
        }
        [Given("a valid user with the user details")]
        public void GivenAValidUserWithTheUserDetails()
        {
            _authService.Should().NotBeNull();
        }

        [Given("I have a valid access token")]
        public void GivenIHaveAValidAccessToken()
        {

            _testContext.AccessToken.Should()
                .NotBeNullOrWhiteSpace();
        }

        [When("I authenticate using the provided authentication endpoint")]
        public async Task WhenIAuthenticateUsingTheProvidedAuthenticationEndpoint()
        {
            _testContext.LoginResponse.Should().NotBeNull();

            _testContext.AccessToken.Should()
                .NotBeNullOrWhiteSpace();

        }

        [When("I request the user details using the access token")]
        public async Task WhenIRequestTheUserDetailsUsingTheAccessToken()
        {
            _testContext.ApiResponse = await _authService.GetCurrentUser(_testContext.AccessToken);
            
            ApiAssertions.AssertOk(_testContext.ApiResponse);

            _testContext.AuthenticatedUser = ResponseHelper.Parse<AuthenticatedUserResponse>(_testContext.ApiResponse);
        }

        [Then("the authentication is successful and an access token is returned")]
        public void ThenTheAuthenticationIsSuccessfulAndAnAccessTokenIsReturned()
        {
            _testContext.AccessToken.Should().NotBeNullOrWhiteSpace();

            _testContext.LoginResponse.Should().NotBeNull();

            _testContext.LoginResponse.AccessToken.Should().NotBeNullOrWhiteSpace();

            _testContext.LoginResponse.Id.Should().BeGreaterThan(0);

        }

        [Then("the user details are returned successfully")]
        public void ThenTheUserDetailsAreReturnedSuccessfully()
        {
            _testContext.AuthenticatedUser
            .Should()
            .NotBeNull();

            _testContext.AuthenticatedUser.Email
                .Should()
                .NotBeNullOrWhiteSpace();

            _testContext.AuthenticatedUser.FirstName
                .Should()
                .NotBeNullOrWhiteSpace();

            _testContext.AuthenticatedUser.LastName
                .Should()
                .NotBeNullOrWhiteSpace();
        }

    } 
}
