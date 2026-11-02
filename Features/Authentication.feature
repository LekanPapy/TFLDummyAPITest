Feature: Authentication

Test to authenticate user 
@auth
Scenario: Authenticate user and store access 
	Given  a valid user with the user details 
	When I authenticate using the provided authentication endpoint
	Then the authentication is successful and an access token is returned	


@auth
Scenario: [Validate authenticated user details]
	Given I have a valid access token
	When I request the user details using the access token
	Then the user details are returned successfully
