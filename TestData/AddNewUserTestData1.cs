
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.TestData
{
    public static class AddNewUserTestData1
    {
        public static object CreateUser()
        {
            return new AddUserRequest
            {
                FirstName = "Lekan",
                LastName = "Tester",
                Age = 35,
                Gender = "Male",

                Hair = new Hair
                {
                    Color = "Black",
                    Type = "Curly"
                },

                Address = new Address
                {
                    AddressLine = "1 High Street",
                    City = "London",
                    State = "Greater London",
                    PostalCode = "SW1A1AA"
                }
            };
        }
    }
}