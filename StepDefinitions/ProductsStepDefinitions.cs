using FluentAssertions;
using Reqnroll;
using TflDummyJsonRestApiTests.Helpers;
using TflDummyJsonRestApiTests.Services;

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

        [Given("I have a list of products with pagination")]
        public void GivenIHaveAListOfProductsWithPagination()
        {
            
        }

        [Given("I want to update the product with ID {int}")]
        public void GivenIWantToUpdateTheProductWithID(int productId)
        {
            _testContext.ProductId = productId;

            _testContext.UpdateProductRequest = new Models.UpdateProductRequest
            {
                Title = "Updated Product Title"
            };
        }

        [When("I request the product details")]
        public async Task WhenIRequestTheProductDetails()
        {
            _testContext.ProductResponse = await _productsService.SearchProduct(_testContext.ProductName);
        }

        [When("I request the 15th product")]
        public async Task WhenIRequestThe15thProduct()
        {
            _testContext.ProductResponse = await _productsService.GetFifteenthProduct();

        }

        [When("I submit a request to update the product details with the product update payload:")]
        public async Task WhenISubmitARequestToUpdateTheProductDetailsWithTheProductUpdatePayload()
        {
            _testContext.Product = await _productsService.UpdateProduct(
                _testContext.ProductId, _testContext.UpdateProductRequest);
        }

        [Then("the response should contain the correct price for {string}")]
        public void ThenTheResponseShouldContainTheCorrectPriceFor(string productName)
        {
            var product = _testContext.ProductResponse.Products.FirstOrDefault(p => p.Title.Equals(productName, StringComparison.OrdinalIgnoreCase));
            product.Should().NotBeNull();

            product!.Price.Should().BeGreaterThan(0);
            product.Price.Should().Be(1099.99m, because: $"the expected price for {productName} is 1099.99");
        
        }

        [Then("Product ID, Name, and Price should be validated against expected values")]
        public void ThenProductIDNameAndPriceShouldBeValidatedAgainstExpectedValues()
        {
            var product = _testContext.ProductResponse.Products.First();
            
            product.Should().NotBeNull();

            product.Id.Should().Be(121);

            product.Price.Should().BeGreaterThan(0);

        }

        [Then("the product should be updated successfully")]
        public void ThenTheProductShouldBeUpdatedSuccessfully()
        {
            _testContext.Product.Should().NotBeNull();

            _testContext.Product.Title.Should().Be(_testContext.UpdateProductRequest.Title);

            _testContext.Product.Id.Should().Be(121);
        }

        [Then("Product should have ID {int}, Price {float} and title be validated to be {string}")]
        public void ThenProductShouldHaveIDPriceAndTitleBeValidatedToBe(int expectedProductId, decimal expectedPrice, string expectedTitle)
        {
            _testContext.ProductResponse.Should().NotBeNull();

            _testContext.ProductResponse.Products.Should().HaveCount(1);

            var product = _testContext.ProductResponse.Products.First();
            product.Id.Should().Be(expectedProductId);
            product.Price.Should().Be(expectedPrice);
            product.Title.Should().Be(expectedTitle);
        }

}
}
