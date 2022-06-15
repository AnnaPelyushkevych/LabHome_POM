Feature: RozetkaTest

  As a 'Rozetka' user
  I want to be able to search products
  So that I can use cart functionality of the site

A short summary of the feature

@MyTest
Scenario: [Check and compare product price]
	Given User opens rozetka home page
	When   User searches '<product name>' using search input
	And   User filters by '<product brand>'
	And   User sorts products by expensive
	And   User selects first item
	And  User adds product to shopping cart
	Then  User checks that '<price>'is grater than treshhold

	Examples: 
	  | product name     | product brand    | price			  |
      |  Ноутбуки        | HP               | 50000			  |