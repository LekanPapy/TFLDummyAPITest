Feature: Cart

A short summary of the feature

@cart
Scenario: Add 5 products to cart
	Given I have added five products
	When I create a cart
	Then the discount percentage total should be correct

Scenario: Delete a cart
	Given I have a cart with id 1
	When I delete the cart
	Then the cart should be deleted successfully