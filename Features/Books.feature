Feature: Books
	Verify Books functionalities

@ui
Scenario: Check details of existing book
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	When I select specific book <name> and choose 'Details'
	Then I see details book element 'BLUE'

Examples: 
	| username | password | name |
	| admin    | 123456   | BLUE |

@ui
Scenario: Delete existing book
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	And I select specific book <name> and choose 'Delete'
	When I select delete book option
	Then I see book 'Marry' is not present on books page

Examples: 
	| username | password | name  |
	| admin    | 123456   | Marry |

@ui
Scenario: Edit existing book
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	And I select specific book <name> and choose 'Edit'
	When I edit book to name 'Bingo123!'
	Then I see book 'Bingo123!' is present on books page after editing

Examples: 
	| username | password | name      |
	| admin    | 123456   | bugXPName |

@ui
Scenario: Create new book
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	And I select create new book option
	When I enter and create new book with <name>, <author>, <genre> and <quantity>
	Then I see book <name> is present on books page after creation

Examples: 
	| username | password | name    | author  | genre  | quantity |
	| admin    | 123456   | Rest123 | John M. | Comedy | 2        |

@ui
Scenario: Verify correct error is returned with incorrect book creation details
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	And I select create new book option
	And I click create new book button
	And I see error message for quantity
	When I enter and create new book with incorrect details
	Then I validate correct error is shown

Examples: 
	| username | password | name    | author  | genre  | quantity |
	| admin    | 123456   | Rest123 | John M. | Comedy | 2        |