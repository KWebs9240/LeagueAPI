Feature: Champion
	In order to avoid silly mistakes
	while getting champion information
	I want to make sure I don't break it

@mytag
Scenario: Get Basic Champion Information
	Given I've set my APIKey
	When I get champion information for ChampID 50
	Then I've gotten information for "Swain"
