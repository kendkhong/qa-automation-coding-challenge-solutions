Feature: SearchRepoApplication
	In order to maintain an easy overview of students progress
	As an owner of a web development school
	I use a simplistic method to get a simple list of github repos owned by a given student, 
	and see the most basic details of each repo


Scenario: Search repos completed successfully
	Given I am on the search github repos form screen
		And I enter a github user name of kendkhong
	When I submit my search repos form 
	Then I should see the search result section for kendkhong

Scenario: No search result returned for non-existed github user name
	Given I am on the search github repos form screen
		And I enter a github user name of kenkhong
	When I submit my search repos form
	Then I should see no search result section for kenkhong

