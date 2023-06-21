Feature: Rest
Relevant API tests

Scenario: Add a user
	Given I input name "Mike"
	When I send create user request
	Then validate user "Mike" is created

Scenario: Get a user
	Given I input id '691'
	When I send get user request
	Then validate '691' user is received

Scenario: Add a book
	Given I input name "Ocean"
	When I send create user request
	Then validate user "Ocean" is created

#	There is a problem with PUT and DELETE methods, they are not allowed
#Scenario: Update a user
#	Given I update user name to "Ganch"
#	And I update user '691'
#	When I send get user request for user '691'
#	Then I validate user is updated successfully


Scenario: Return a book
	Given I return book for user '1413'
	And I update user '691'
	When I send get user request for user '691'
	Then I validate user is updated successfully
