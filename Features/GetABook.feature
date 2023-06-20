Feature: GetABook
	Verify GetABook functionalities

@ui
Scenario: Get a new book and verify that the quantity of books decreased
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	And I select create new book option
	And I enter and create new book with <name>, <author>, <genre> and <quantity>
	And I see book <name> is present on books page after creation
	And I select tab GetABook
	When I select create new book option
	Then I enter and get new book with <userId> and <bookId>
	And I select tab Books
	And I select specific book <name> and choose 'Details'
	And I see quantity of book is '1'

Examples: 
	| username | password | name               | author     | genre  | quantity | userId | bookId     |
	| admin    | 123456   | RestTerminatorsddr | John Msqt. | Comedy | 2        | 9876   | John Msqt. |

#	@ui
#Scenario: Remove a new book and verify that the quantity of books increased
#	Given Homepage is open
#	And I log in <username> and <password>
#	And I am successfully logged in
#	And I select tab Books
#	And I select create new book option
#	And I enter and create new book with <name>, <author>, <genre> and <quantity>
#	And I see book <name> is present on books page after creation
#	And I select tab GetABook
#	When I select specific book <author> and choose 'Delete'
#	Then I select delete book option
#	And I select tab Books
#	And I select specific book <name> and choose 'Details'
#	And I see quantity of book is '3'
#
#Examples: 
#	| username | password | name                 | author     | genre  | quantity | userId | bookId     |
#	| admin    | 123456   | RestTerminatorsddrtw | John Msqt. | Comedy | 2        | 9876   | John Msqt. |