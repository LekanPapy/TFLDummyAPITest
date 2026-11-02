using FluentAssertions;
using Reqnroll;
using TflDummyJsonRestApiTests.Helpers;
using TflDummyJsonRestApiTests.Services;
using TflDummyJsonRestApiTests.TestData;

namespace TflDummyJsonRestApiTests.StepDefinitions
{
    [Binding]
    public class UsersStepDefinitions
    {
        private readonly TestContext _testContext;
        private readonly UserService _usersService;
        public UsersStepDefinitions(TestContext testContext)
        {
            _testContext = testContext;
            _usersService = new UserService();
        }
     
        [Given("I want to retrieve all users with red hair")]
        public async Task GivenIWantToRetrieveAllUsersWithRedHair()
        {
          _testContext.UserResponse = await _usersService.GetAllUsers();
        }

        [Given("I want to add a new user with a user payload")]
        public void GivenIWantToAddANewUserWithAUserPayload()
        {
            _testContext.AddUserRequest = (Models.AddUserRequest)AddNewUserTestData1.CreateUser();
        }

        [When("I request the list of users with red hair")]
        public void WhenIRequestTheListOfUsersWithRedHair()
        {
            _testContext.RedHairUsers = _testContext.UserResponse.Users
                .Where(u => u.Hair.Color.Equals("Red", StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine($"Number of users with red hair: {_testContext.RedHairUsers.Count}");
        }

        [When("I submit the request to add a new user")]
        public async Task WhenISubmitTheRequestToAddANewUser()
        {
            _testContext.AddUserResponse = await _usersService.AddUser(_testContext.AddUserRequest);
        }

        [Then("the user should be added successfully")]
        public void ThenTheUserShouldBeAddedSuccessfully()
        {
            _testContext.AddUserResponse.Should()
             .NotBeNull();

            _testContext.AddUserResponse.Id
                .Should()
                .BeGreaterThan(0);

            var response = _testContext.AddUserResponse!;
            var request = _testContext.AddUserRequest!;

            response.FirstName.Should().Be(request.FirstName);


        }

        [Then("the response should contain the correct number of users with red hair plus their expected attributes")]
        public void ThenTheResponseShouldContainTheCorrectNumberOfUsersWithRedHairPlusTheirExpectedAttribute()
        {
            foreach (var user in _testContext.RedHairUsers)
            {
                user.Hair.Color.Should().Be("Red");

                user.Hair.Type.Should().NotBeNullOrEmpty();

                user.Id.Should().BeGreaterThan(0);

                user.FirstName.Should().NotBeNullOrEmpty();

                user.LastName.Should().NotBeNullOrEmpty();

            }
        }

}
}
