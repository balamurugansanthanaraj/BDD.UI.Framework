@CalculatorGUI
Feature: CodeProject Smoke Test

Scenario: 01_CodeProject Navigation.
	Given Launch a browser with url "http://www.codeproject.com/"
	And I select following items from the menu
	| Items    |
	| Home     |
	| Help     |
	| Articles |
	#When I press enter
	#Then the result should display


Scenario: 02_CodeProject Help Navigation.
	Given Launch a browser with url "http://www.codeproject.com/"
	And I select 'Help' from the menu

#Scenario: 03_Gmail Login
#	Given Launch a browser with url "https://accounts.google.com/ServiceLogin?service=mail&continue=https://mail.google.com/mail/#identifier"
#	And I Login
#	#When I press enter
#	#Then the result should display
