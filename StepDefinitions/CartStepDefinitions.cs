using System;
using Reqnroll;
using TflDummyJsonRestApiTests.Services;
using TflDummyJsonRestApiTests.Models;
using TflDummyJsonRestApiTests.TestData;
using TflDummyJsonRestApiTests.Helpers;
using FluentAssertions;

namespace TflDummyJsonRestApiTests.StepDefinitions
{
    [Binding]
    public class CartStepDefinitions
    {
        private readonly TestContext _testContext;
        private readonly CartService _cartService;
       
            public CartStepDefinitions(TestContext testContext)
        {    _testContext = testContext;
            _cartService = new CartService();
        }
        [Given("I have added five products")]
        public void GivenIHaveAddedFiveProducts()
        {
            _testContext.AddCartRequest = CartTestData.CreateCart();
            
        }

        [Given("I have a cart with id {int}")]
        public void GivenIHaveACartWithId(int cartId)
        {
            _testContext.CartId = cartId;
        }

        [When("I create a cart")]
        public async Task WhenICreateACart()
        {
            _testContext.AddCartResponse = await _cartService.AddCart(_testContext.AddCartRequest);
        }

        [When("I delete the cart")]
        public async Task WhenIDeleteTheCart()
        {
            _testContext.DeleteCartResponse = await _cartService.DeleteCart(_testContext.CartId);
        }

        [Then("the discount percentage total should be correct")]
        public void ThenTheDiscountPercentageTotalShouldBeCorrect()
        {
            _testContext.AddCartResponse.Should().NotBeNull();

            var totalDiscountPercentage = _testContext.AddCartResponse.Products.Sum(p => p.DiscountPercentage);
            totalDiscountPercentage.Should().BeGreaterThan(0);

            Console.WriteLine($"Total Discount Percentage: {totalDiscountPercentage}");
        }

        [Then("the cart should be deleted successfully")]
        public void ThenTheCartShouldBeDeletedSuccessfully()
        {
           var response = _testContext.DeleteCartResponse;
            response.Should().NotBeNull();

            response.IsDeleted.Should().BeTrue();

            response.DeletedOn.Should().NotBeNullOrEmpty();

            Console.WriteLine($"Cart with ID {response.Id} deleted on {response.DeletedOn}");
        }
    }
}
