#This shows that we don't actually need to have the ide extension installed - although it does help.

Feature: Foobar

Scenario: Add one to calculator total
Given The register has a value of 1
When I Add 2
Then the register will show 3

Scenario: Multiple additions
Given The register has a value of 1
When I Add 2
And I Add 5
Then the register will show 8