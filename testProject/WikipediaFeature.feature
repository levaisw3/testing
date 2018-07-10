Feature: WikipediaFeature
	Scenario: Validation in the chosen wikipedia page
	Given I open my webbrowser
	And I navigate to the wikipedia site: "https://www.wikipedia.org/"
	And I choose the English language
	When I search for "Test Automation"
	Then "Unit testing" text exists in this page
	And "Test Automation Interface Model" picture exists
	And I search for the link of Behavior driven development
	And I navigate to that page
