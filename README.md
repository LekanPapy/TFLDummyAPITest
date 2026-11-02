# TFLDummyAPITest
DummyJSON API Automation Framework
Overview

This project is a C# API Automation Framework developed to test the DummyJSON REST API.

The framework has been designed using Behaviour Driven Development (BDD) principles with Reqnroll (SpecFlow successor), NUnit, RestSharp, and FluentAssertions.

The solution validates:

Authentication
Users
Products
Carts

The framework executes API requests, validates response status codes, validates response payloads and verifies response attributes as required by the challenge.

Technology Stack
Technology	PurposeC# (.NET 8)	Programming Language
Reqnroll	BDD Framework
NUnit	Test Framework
RestSharp	API Client
FluentAssertions	Assertions
Newtonsoft.Json	JSON Serialization / Deserialization
GitHub Actions	CI/CD
Framework Design

The framework follows a layered architecture:

Plain Text
TflDummyJsonRestApiTests
│
├── Features
├── StepDefinitions
├── Services
├── Models
├── TestData
├── Helpers
├── Hooks
├── Configuration
│
├── appsettings.json
│
└── README.md
Features Layer

Contains all Gherkin scenarios.

Example:

Cucumber
Scenario: Authenticate user and store access token
Given a valid user
When I authenticate using the provided authentication endpoint
Then the authentication is successful and an access token is returned
Step Definitions Layer

Contains all automation logic that maps to Gherkin steps.

Example:

C#
[When(@"I create a cart")]
public async Task WhenICreateACart()
{
_testContext.AddCartResponse =
await _cartService.AddCart(
_testContext.AddCartRequest);
}
Service Layer

Handles all interactions with the API.

Example:

C#
public async Task<LoginResponse> Login(LoginRequest requestBody)
{
var request =
new RestRequest("/auth/login", Method.Post);
 
request.AddJsonBody(requestBody);
 
var response =
await SendAsync(request);
 
return JsonConvert.DeserializeObject<LoginResponse>(
response.Content!)!;
}
Models Layer

Contains strongly typed request and response models.

Example:

C#
public class LoginRequest
{
[JsonProperty("username")]
public string Username { get; set; }
 
[JsonProperty("password")]
public string Password { get; set; }
}

Using strongly typed models improves maintainability and readability while avoiding the use of dynamic objects.

TestData Layer

Stores reusable test data outside of step definitions.

Example:

C#
public static class CartTestData
{
public static AddCartRequest CreateCart()
{
return new AddCartRequest
{
UserId = 1
};
}
}

This prevents test data from being hard coded inside automation logic.

TestContext

A custom TestContext class is used to share data between steps within a scenario.

Example:

C#
public class TestContext
{
public string AccessToken { get; set; }
 
public LoginResponse LoginResponse { get; set; }
 
public AddUserResponse AddUserResponse { get; set; }
 
public AddCartResponse AddCartResponse { get; set; }
}
Hooks

Authentication is handled through a BeforeScenario Hook.

Example:

C#
[BeforeScenario("@auth")]
public async Task Authenticate()
{
var response =
await _authService.Login(request);
 
_testContext.AccessToken =
response.AccessToken;
}

This guarantees that all authenticated scenarios are executed with a valid access token.

Configuration

Configuration values are externalised into:

Plain Text
appsettings.json

Example:

JSON
{
"BaseUrl": "https://dummyjson.com",
 
"AuthSettings": {
"Username": "emilys",
"Password": "emilyspass",
"ExpiresInMins": 30
}
}

This removes credentials from automation code.

Test Coverage
Authentication
Scenario 1

Authenticate a user and store an access token.

Validations:

Status Code
Access Token returned
User Id returned
Scenario 2

Get current authenticated user.

Validations:

Id
First Name
Last Name
Email Address
Users
Scenario 3

Verify users with red hair.

Validations:

Count of users with red hair
Count greater than zero
Scenario 4

Validate red-haired user details.

Validations:

User Id
First Name
Last Name
Hair Colour
Scenario 5

Add a new user.

Validations:

User created successfully
First Name
Last Name
Age
Gender
Hair Colour
Hair Type
Address
Products
Scenario 6

Verify price of iPhone 13 Pro.

Validations:

Product exists
Product price returned
Scenario 7

Retrieve only the 15th product using pagination.

Request:

HTTP
GET /products?limit=1&skip=14

Validations:

Product Id
Product Title
Product Price
Only one product returned
Scenario 8

Update Product ID 121.

Validations:

Product updated successfully
Updated title returned in response
Cart
Scenario 9

Add 5 products to a cart.

Validations:

Cart created successfully
Total discount percentage calculated correctly

Note:

DummyJSON does not provide a cart-level discount percentage total. Therefore the framework calculates the total discount percentage by summing the individual product discount percentages returned in the response.

Scenario 10

Delete a cart.

Validations:

Cart marked as deleted
Correct cart id returned
Deletion timestamp returned
Running Tests

Restore packages:

Shell
dotnet restore
 

Build solution:

Shell
dotnet build

Execute tests:

Shell
dotnet test
CI/CD

A GitHub Actions pipeline has been included to automatically execute tests on each push and pull request.

Pipeline actions:

YAML
dotnet restore
dotnet build
dotnet test
 
Development Decisions

The following design decisions were made:

Service Layer Pattern used to separate test logic from API interactions.
Strongly Typed Models used instead of dynamic objects.
Test Data separated from automation logic.
Authentication centralised using Hooks.
TestContext used to share data between steps.
FluentAssertions used for expressive assertions.
Configuration externalised from source code.