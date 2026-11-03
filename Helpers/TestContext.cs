

using RestSharp;
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.Helpers
{
    public class TestContext
    {
        public string AccessToken { get; set; }

        public LoginResponse LoginResponse { get; set; }

        public LoginRequest LoginRequest { get; set; }

        public AuthenticatedUserResponse AuthenticatedUser { get; set; }

        public AddUserRequest AddUserRequest { get; set; }

        public AddUserResponse AddUserResponse { get; set; }

        public UserResponse UserResponse { get; set; }

        public List<User> RedHairUsers { get; set; } = new();

        public AddCartRequest AddCartRequest { get; set; }

        public AddCartResponse AddCartResponse { get; set; }

        public int CartId { get; set; }

        public DeleteCartResponse DeleteCartResponse { get; set; }

        public string ProductName { get; set; }

        public ProductResponse ProductResponse { get; set; }

        public Product Product { get; set; }

        public int ProductId { get; set; }

        public UpdateProductRequest UpdateProductRequest { get; set; }

        public RestResponse ApiResponse { get; set; }

    }
}
