Feature: Login to SauceDemo
  Scenario: Successful Login
    Given I am on the SauceDemo login page
    When I enter "standard_user" as username and "secret_sauce" as password
    And I click the login button
    Then I should be on the products page