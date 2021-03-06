﻿Feature: Champion
	In order to avoid silly mistakes
	while getting champion information
	I want to make sure I don't break it

@mytag
Scenario: Get Basic Champion Information
	Given I've set my APIKey
	When I get champion information for ChampID 50
	Then I've gotten information for "Swain"

Scenario: Get Basic Summoner Information
	Given I've set my APIKey
	When I get summoner information for "Chimp9240"
	Then I've gotten information for summoner Id 27312954

Scenario: Get Last Match Info
	Given I've set my APIKey
	When I get the most recent game for "Chimp9240"
	Then I have a match with a non-zero game id
	And The match has participant identities
	And The match has participants
	And The first participant has stats