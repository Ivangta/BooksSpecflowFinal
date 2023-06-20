Feature: Users
	Verify Users functionalities

@ui
Scenario: Check details of existing user
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	When I select specific user 'ergergb' and choose 'Details'
	Then I see details element

Examples: 
	| username | password | 
	| admin    | 123456   |

@ui
Scenario: Delete existing user
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	When I select specific user 'ergergb' and choose 'Delete'
	Then I select delete option

Examples: 
	| username | password | 
	| admin    | 123456   |

@ui
Scenario: Edit existing user
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	When I select specific user 'ergergb' and choose 'Edit'
	Then I edit user

Examples: 
	| username | password | 
	| admin    | 123456   |

@ui
Scenario: Create new user
	Given Homepage is open
	And I log in <username> and <password>
	And I am successfully logged in
	And I select on create new user option
	When I enter and create new user 'Bay123456789!'
	Then I see new user 'Bay123456!' on users page

Examples: 
	| username | password | 
	| admin    | 123456   |