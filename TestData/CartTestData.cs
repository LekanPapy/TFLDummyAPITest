
using TflDummyJsonRestApiTests.Models;

namespace TflDummyJsonRestApiTests.TestData
{
    public static class CartTestData
    {
        public static AddCartRequest CreateCart()
        {
            return new AddCartRequest
            {
                UserId = 1,
                Products =
                [
                new() { Id = 1, Quantity = 1 },
                new() { Id = 2, Quantity = 1 },
                new() { Id = 3, Quantity = 1 },
                new() { Id = 4, Quantity = 1 },
                new() { Id = 5, Quantity = 1 }
                ]
            };
        }
    }
}