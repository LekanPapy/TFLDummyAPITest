Feature: Products

A short summary of the feature

@products
Scenario: [Verify Price of iPhone 13 Pro]
	Given I search for the product "iPhone 13 Pro"
	When I request the product details
	Then the response should contain the correct price for "iPhone 13 Pro"

Scenario: [Retrieve and Validate only the 15th Product Using Pagination]
	When I request the 15th product
	Then Product should have ID 15, Price 799.99 and title be validated to be "Wooden Bathroom Sink With Mirror"


Scenario: [Update Product 121]
	Given I want to update the product with ID 121
	When I submit a request to update the product details with the product update payload:
	Then the product should be updated successfully
