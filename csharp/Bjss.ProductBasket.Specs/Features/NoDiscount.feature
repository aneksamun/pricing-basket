Feature: No discount
	In order to buy items
	As a buyer
	I want to be pay for them

Scenario: No discount should be applied buying items with no offer
	Given I have added products with no offers
	| product | price |
	| milk    | 1.30  |
	| soap    | 0.65  |
	| bread   | 0.80  |
	When I pricing items in basket
	Then the normal price should be calculated
