Feature: Rest
Relevant API tests

Scenario: Add a user
	Given I input name "Mike"
	When I send create user request
	Then validate user is created

Scenario: Get a user
	Given I input name "Mike"
	And I send get user request for user '691'
	Then validate user is recieved
