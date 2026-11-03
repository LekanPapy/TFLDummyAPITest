# DummyJSON API Automation Framework

## Overview

This project is a C# API Automation Framework developed to test the DummyJSON REST API.

The framework has been designed using Behaviour Driven Development (BDD) principles with Reqnroll, NUnit, RestSharp and FluentAssertions.

The solution validates:

- Authentication
- Users
- Products
- Carts

The framework executes API requests, validates response status codes, validates response payloads and verifies response attributes as required by the challenge.

---

# Technology Stack

| Technology | Purpose |
|------------|---------|
| C# (.NET 8) | Programming Language |
| Reqnroll | BDD Framework |
| NUnit | Test Framework |
| RestSharp | API Client |
| FluentAssertions | Assertion Library |
| Newtonsoft.Json | Serialization / Deserialization |

---

# Framework Design

The framework follows a layered architecture:

```text
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
```

---

## Features Layer

Contains all Gherkin scenarios that define application behaviour.

Example:

```gherkin
Scenario: Authenticate user and store access token
    Given a valid user
    When I authenticate using the provided authentication endpoint
    Then the authentication is successful and an access token is returned
```

---

## Step Definitions Layer

Contains the implementation of each Gherkin step and all validations.

Example:

```csharp
[When(@"I create a cart")]
public async Task WhenICreateACart()
{
    _testContext.AddCartResponse =
        await _cartService.AddCart(
            _testContext.AddCartRequest);
}
```

---

## Service Layer

Responsible for interacting with the API endpoints.

Example:

```csharp
 public async Task<RestResponse> Login(LoginRequest loginRequest)
    {
       var request = new RestRequest(
          
         "/auth/login", Method.Post);

       request.AddJsonBody(loginRequest);
           
       return await SendAsync(request);
        }
}
```

---

## Models Layer

Contains strongly typed request and response models used for API communication.

Example:

```csharp
public class LoginRequest
{
    [JsonProperty("username")]
    public string Username { get; set; }

    [JsonProperty("password")]
    public string Password { get; set; }
}
```

Strongly typed models improve:

- Maintainability
- Readability
- Type Safety
- Reusability

---

## Test Data Layer

Contains reusable test data separated from test logic.

Example:

```csharp
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
```

This approach prevents hard-coded values from being embedded within test scripts.

---

## TestContext

A shared context object is used to pass data between steps within the same scenario.

Example:

```csharp
public class TestContext
{
    public string AccessToken { get; set; }

    public LoginResponse LoginResponse { get; set; }

    public AddUserResponse AddUserResponse { get; set; }

    public AddCartResponse AddCartResponse { get; set; }
}
```

---

## Hooks

Authentication is centralised using a BeforeScenario Hook.

Example:

```csharp
[BeforeScenario("@auth")]
public async Task Authenticate()
{
    var response =
        await _authService.Login(request);

    _testContext.AccessToken =
        response.AccessToken;
}
```

This ensures that every authenticated scenario begins with a valid access token.

---

# Configuration Management

Configuration values are externalised into:

```text
appsettings.json
```

Example:

```json
{
  "BaseUrl": "https://dummyjson.com",
  "AuthSettings": {
    "Username": "emilys",
    "Password": "emilyspass",
    "ExpiresInMins": 30
  }
}
```

Benefits:

- Credentials are not hard-coded.
- Configuration can be changed without code changes.
- Easier environment management.

---

# Test Coverage

## Authentication

### Scenario 1 - Authenticate User and Store Access Token

Validations:

- HTTP 200 returned
- Access Token generated
- User Id returned

### Scenario 2 - Validate Current Authenticated User

Validations:

- Id returned
- First Name returned
- Last Name returned
- Email returned

---

## Users

### Scenario 3 - Verify and validate numbers of Users with Red Hair

Validations:

- User Id
- First Name
- Last Name
- Hair Colour
- - Retrieve all users
- Count red-haired users
- Verify count is greater than zero

### Scenario 4 - Add New User

Validations:

- User created successfully
- First Name
- Last Name
- Age
- Gender
- Hair Colour
- Hair Type
- Address

---

## Products

### Scenario 5 - Verify iPhone 13 Pro Price

Validations:

- Product returned
- Product title matches search criteria
- Product price returned

### Scenario 6 - Retrieve and Validate the 15th Product Using Pagination

Request:

```http
GET /products?limit=1&skip=14
```

Validations:

- Product Id = 15
- Product Title = Wooden Bathroom Sink With Mirror
- Product Price = 799.99
- Only one product returned

### Scenario 7 - Update Product 121

Validations:

- Product updated successfully
- Response contains updated product title
- Product Id remains 121

---

## Carts

### Scenario 8 - Add Five Products to a Cart

Validations:

- Cart created successfully
- Cart contains 5 products
- Total discount percentage calculated correctly

Example Calculation:

```csharp
var totalDiscountPercentage =
    response.Products.Sum(
        x => x.DiscountPercentage);
```

### Scenario 9 - Delete Cart

Validations:

- Correct cart deleted
- Cart marked as deleted
- Deletion timestamp returned

---

# Running the Tests

### Restore Packages

```bash
dotnet restore
```

### Build Solution

```bash
dotnet build
```

### Execute Tests

```bash
dotnet test
```

### Execute Specific Feature

```bash
dotnet test --filter Category=auth
```

---

# Continuous Integration

GitHub Actions pipeline executes:

```yaml
dotnet restore
dotnet build
dotnet test
```

on:

- Push
- Pull Request

---

# Framework Design Decisions

The following design decisions were implemented:

### Service Layer Pattern

Separates API interaction from test logic.

### Strongly Typed Models

Eliminates use of dynamic objects.

### Shared TestContext

Allows data sharing across steps.

### Hook-Based Authentication

Avoids duplicated authentication logic.

### TestData Separation

Keeps payload data outside of test implementation.

### FluentAssertions

Provides readable and maintainable assertions.

### Configuration Management

Separates configuration from source code.

---

# Assumptions

DummyJSON is a stateless mock API.

Write operations including:

- POST
- PUT
- PATCH
- DELETE

are simulated only and are not persisted.

Therefore tests validate:

- Request Structure
- Response Status Codes
- Response Payloads
- Response Attributes

and do not attempt to verify persistence through subsequent requests.

---

# Future Improvements

Potential enhancements include:

- Serilog Logging
- Extent Reports
- Parallel Test Execution
- Azure DevOps Pipeline
- Environment-Specific Configuration
- Contract Testing
- Retry Policies
- API Test Data Builders

---

# AI Usage Disclaimer

AI tools were used to assist with:

- Framework design guidance
- Code scaffolding
- Request and response model generation
- Documentation drafting

All generated code was reviewed, tested, modified and validated before submission.

---

# Author

**Lekan Tairu **

API Automation Framework created as part of the DummyJSON REST API Automation Challenge.