Feature: Books
	Verify Books functionalities

@ui
Scenario: Check details of existing book
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	When I select specific book 'BLUE' and choose 'Details'
	Then I see details book element 'BLUE'

Examples: 
	| username | password | 
	| admin    | 123456   |

@ui
Scenario: Delete existing book
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	And I select specific book 'Marry' and choose 'Delete'
	When I select delete option
	Then I see book 'Marry' is not present on books page

Examples: 
	| username | password | 
	| admin    | 123456   |

@ui
Scenario: Edit existing book
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	And I select specific book 'bugXPName' and choose 'Edit'
	When I edit book to name 'Bingo123!'
	Then I see book 'Bingo123!' is present on books page

Examples: 
	| username | password | 
	| admin    | 123456   |

@ui
Scenario: Create new book
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	And I select on create new user option
	When I enter and create new user 'Bay123456789!'
	Then I see new user 'Bay123456!' on users page

Examples: 
	| username | password | 
	| admin    | 123456   |