Feature: GoogleSearch
	Feature to test Google page search functionality
	Auto-search and navigation to search result

@SmokeTest
@Browser:Chrome
Scenario: Google Saerch for Wikipedia
	Given I have navigated to Google page
	And I see the Google page fully loaded
	When I type search keyword as
	|Keyword	|
	| wikipedia |
	Then is hould see the result for keyword
	|Keyword	|
	| wikipedia |
