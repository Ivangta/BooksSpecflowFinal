Feature: Login
	Verify Login functionality

@ui
Scenario: Login with existing user
	Given Homepage is open
	When I log in <username> and <password>
	Then I am successfully logged in

Examples: 
	| username | password |
	| admin    | 123456   |