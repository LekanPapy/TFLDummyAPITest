using FluentAssertions;
using Reqnroll;
using TflDummyJsonRestApiTests.Helpers;
using TflDummyJsonRestApiTests.Services;
using TflDummyJsonRestApiTests.TestData;
using Newtonsoft.Json;
using TflDummyJsonRestApiTests.Models;
using System.Net;

namespace TflDummyJsonRestApiTests.StepDefinitions
{
    [Binding]
    public class ProductsStepDefinitions
    {
        private readonly ProductsService _productsService;
        private TestContext _testContext;

        public ProductsStepDefinitions(TestContext testContext)
        {
            _testContext = testContext;
            _productsService = new ProductsService();
        }

        [Given("I search for the product {string}")]
        public void GivenISearchForTheProduct(string productName)
        {
            _testContext.ProductName = productName;

        }

        [Given("I want to update the product with ID {int}")]
        public void GivenIWantToUpdateTheProductWithID(int productId)
        {
            _testContext.ProductId = productId;

            _testContext.UpdateProductRequest = ProductTestData.GetUpdatedProduct();
            
        }

        [When("I request the product details")]
        public async Task WhenIRequestTheProductDetails()
        {
            _testContext.ApiResponse = await _productsService.SearchProduct(_testContext.ProductName);

            ApiAssertions.AssertOk(_testContext.ApiResponse);

            _testContext.ProductResponse = ResponseHelper.Parse<ProductResponse>(_testContext.ApiResponse);
        }

        [When("I submit a request to update the product details with the product update payload:")]
        public async Task WhenISubmitARequestToUpdateTheProductDetailsWithTheProductUpdatePayload()
        {
            _testContext.ApiResponse = await _productsService.UpdateProduct(
                _testContext.ProductId, _testContext.UpdateProductRequest);
          
            ApiAssertions.AssertOk(_testContext.ApiResponse);

            Console.WriteLine(_testContext.ApiResponse.Content);

            _testContext.Product = ResponseHelper.Parse<Product>(_testContext.ApiResponse);
        }

        [Then("the response should contain the correct price for {string}")]
        public void ThenTheResponseShouldContainTheCorrectPriceFor(string productName)
        {
            var product = _testContext.ProductResponse.Products.FirstOrDefault(p => 

            p.Title.Equals(productName, StringComparison.OrdinalIgnoreCase));
            
            product.Should().NotBeNull();

            product!.Price.Should().BeGreaterThan(0);

            product.Price.Should().Be(ProductTestData.ExpectedIphone13ProPrice, 

                because: $"the expected price for {productName} is 1099.99");
        
        }


        [Then("the product should be updated successfully")]
        public void ThenTheProductShouldBeUpdatedSuccessfully()
        {
            _testContext.Product.Should().NotBeNull();

            _testContext.Product.Id.Should().Be(ProductTestData.ExpectedUpdatedProductId);

            _testContext.Product.Title.Should().Be(_testContext.UpdateProductRequest.Title);
        }

        [When("I request the 15th product with the pagination request function")]
        public async Task WhenIRequestThe15thProductWithThePaginationRequestFunction()
        {
            _testContext.ApiResponse =
                await _productsService.GetFifteenthProduct();
             
            ApiAssertions.AssertOk(_testContext.ApiResponse);

            _testContext.ProductResponse = ResponseHelper.Parse<ProductResponse>(_testContext.ApiResponse);

        }

        [Then("the 15th product should match the expected product details")]
        public void ThenThe15thProductShouldMatchTheExpectedProductDetails()
        {
  
            _testContext.ProductResponse.Products.Should().HaveCount(1);

            var product = _testContext.ProductResponse.Products.First();

            product.Id.Should().Be(ProductTestData.ExpectedFifteenthProductId);

            product.Price.Should().Be(ProductTestData.ExpectedFifteenthProductPrice);

            product.Title.Should().Be(ProductTestData.ExpectedFifteenthProductTitle);
        }  

}
}
