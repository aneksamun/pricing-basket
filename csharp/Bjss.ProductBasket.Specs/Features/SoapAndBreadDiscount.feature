Feature: Soap and bread discount
	In order to save money
	As a buyer
	I want to get a special discount between items

Scenario: Pricing bread with discount
	Given I have added products with special offer
	| product | price |
	| soup    | 0.65  |
	| soup    | 0.65  |
	| bread   | 0.80  |
	When I buying items
	Then the bread should be sold by half price 
