Feature: Books
	Verify Books functionalities

@ui
Scenario: Check details of existing book
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select tab Books
	When I select specific book 'BLUE' and choose 'Details'
	Then I see details book element 'SCIFICTION'

Examples: 
	| username | password | 
	| admin    | 123456   |