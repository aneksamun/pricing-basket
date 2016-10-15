Feature: Bad product input
	In order to avoid errors
	As a storekeeper
	I want to exclude products not in database

Scenario: Excluding none existing products
	Given I have defined none existing products
	| product |
	| aaaa    |
	| bbbb    |
	When I do pricing
	Then the items should be excluded
