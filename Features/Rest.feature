Feature: Rest
Relevant API tests

Scenario: Add a user
	Given I input user name "Mike"
	When I send create user request
	Then I validate user "Mike" is created

Scenario: Get a user
	Given I input user id '691'
	When I send get user request
	Then I validate '691' user is received

Scenario: Add a book
	Given I input book <name>, <author>, <genre>, <quontity>
	When I send create book request
	Then I validate book "Ocean" is created

Examples: 
	| name  | author  | genre  | quontity |
	| Ocean | John S. | Action | 3        |

Scenario: Get a book
	Given I input book id '1413'
	When I send get book request
	Then I validate '1413' book id is received

Scenario: Take a book
	Given I input book to take <userId>, <bookId>
	And I send get book request for book id '74' to check quantity before change
	When I send take book request
	And I send get book request for book id '74' to check quantity after change
	Then I validate '74' book id quantity has decreased

Examples: 
	| userId | bookId |
	| 1184   | 74     |

#	There is a problem with PUT and DELETE methods, they are not allowed
#Scenario: Update a user
#	Given I update user name to "Ganch"
#	And I update user '691'
#	When I send get user request for user '691'
#	Then I validate user is updated successfully
