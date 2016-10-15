Feature: Apples discount
	In order to save money
	As a buyer
	I want to get discount for items

Scenario: Pricing apples with discount
	Given I have added products into basket
	| product | price |
	| milk    | 1.30  |
	| bread   | 0.80  |
	| apples  | 1.00  |
	When I pricing items
	Then the discount of 10% should be applied for apples
