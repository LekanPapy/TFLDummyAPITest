Feature: Users

A short summary of the feature

@users
Scenario: [Verify and validate numbers of Users with Red Hair]
 Given I want to retrieve all users with red hair
 When I request the list of users with red hair
Then the response should contain the correct number of users with red hair plus their expected attributes 

Scenario: [Add New User]
	Given I want to add a new user with a user payload
	When I submit the request to add a new user
	Then the user should be added successfully


