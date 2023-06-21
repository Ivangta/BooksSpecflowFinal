Feature: Rest
Relevant API tests

Scenario: Add a user
	Given I input user name "Mike"
	When I send create user request
	Then validate user "Mike" is created

Scenario: Get a user
	Given I input user id '691'
	When I send get user request
	Then validate '691' user is received

Scenario: Add a book
	Given I input book <name>, <author>, <genre>, <quontity>
	When I send create book request
	Then validate book "Ocean" is created

Examples: 
	| name  | author  | genre  | quontity |
	| Ocean | John S. | Action | 3        |

Scenario: Get a book
	Given I input book id '1413'
	When I send get book request
	Then validate '1413' book is received

#	There is a problem with PUT and DELETE methods, they are not allowed
#Scenario: Update a user
#	Given I update user name to "Ganch"
#	And I update user '691'
#	When I send get user request for user '691'
#	Then I validate user is updated successfully
