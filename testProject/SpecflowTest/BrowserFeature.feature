Feature: BrowserFeature
Scenario: Test the Google search with the wikipedia keyword
	Given I go to the page "www.google.com"
	And I see the page
	When I enter keyword in the search text box
	| Keyword  |
	| wikipedia |
	And I click Search Button
	Then I see the search result
