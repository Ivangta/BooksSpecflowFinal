Feature: Users
	Verify Users functionalities

@ui
Scenario: Check details of existing user
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	When I select specific user 'ergergb' and choose details
	Then I see details element

Examples: 
	| username | password | 
	| admin    | 123456   |