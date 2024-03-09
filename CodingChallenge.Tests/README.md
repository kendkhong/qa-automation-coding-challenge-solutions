## Overview of test framework structure from the high level:

The 'CodingChallenge.Tests' project contains the following files:
   - SearchGithubRepoApplication.feature
   - SearchGithubRepoApplicationSteps.cs
   - SearchGithubRepoApplicationPage.cs

Descriptions:

1) Feature file has one feature and number of scenarios, and each scenario has number of steps.  These steps map to the methods in the specflow steps class.  And we can have multiple scenario steps mapping to the same method. 

2) The Specflow Steps Class file is where the methods in the specflow steps class used Selenium WebDriver API to locate elements on the html page and interact with them.

3) The Page Object File contains test codes, which it uses Selenium WebDriver API to locate HTML elements and interact with them

3) The HTML page from the 'Get Github Repos' application has number of elements

## Why we use Gherkin?

- Gherkin is a business readable domain specific language
- Gherkin represents tests in a natural language, not code
- Gherkin is line-oriented and uses indentation to create structure
- Gherkin uses keywords such as Feature, Scenario
- Gherkin localized in 40+ spoken languages (French, Japanese, etc.)

## Why we use Specflow?

- Specflow help to bridge the communication gap between the domain expert and the developer
- Specflow represents behavior of the system to create more readable web automation
- Specflow defines a living document system where source code exist in source control system and specification exists alongside source code

## Why we use Page Object Model?

- What happens if the ID of one of html elements that were referencing changes, and for an example this element has been changed. Because two methods in the specflow steps class are referring this element by its ID, both of these methods are going to fail now because they won't be able to locate the html element because the ID no longer exists. Not only these methods fail, but also multiple scenarios in the feature file are going to fail because they shared these methods and one change in the ID in the HTML page.

- This is because test code in specflow steps class's method is tightly coupled to the implementation in the Web UI. In this case is ID but we could also apply to CSS selectors, XPath selectors and selection by name. We may also have code duplication in the steps class method. For example, multiple methods having the same ID as a string in the find element method that we're using to interact with the HTML element.

- As the result, we can use Page Object Model to improve code maintainability and readability of our test automation solutions by indirectly adding another layer into our test code, which it sits between specflow steps class and HTML page. This extra layer helps us to insulate our test code from changes in the UI. Now, rather than the test code in steps class method directly accessing HTML elements, instead going to access the Page Object Model layer. The page object model knows how to locate and interact with the HTML elements on the page. So, our steps class methods no longer have to have intimate details of how the UI is put together. Now, for an example, the ID of an element changes on the HTML page. We simply need to go and update the Page Object Model in a single place. All of these steps class methods are still using the same members of this page object model.

## Implementation and refactoring

1. Injected web automation code in specflow steps class, which interact directly to elements on the HTML page
2. Refactored steps class method code to use Page Object Model layer. Note that old codes commented out for comparison before and after refactoring

## Instruction on how to run test

### Pre-requisites:

   1. Download and install Visual Studio 2022 (Community Edition) and select the following components:
	1. Select 'ASP.NET and Web Development' 
	2. Select 'Node.js development' 
	3. Select '.NET desktop development'
   2. Upon your completion of Visual Studio installation, install 'Specflow for Visual Studio 2022'
	1. Click on 'Extensions' from menu and click on 'Manage Extensions..', then search for 'Specflow for Visual Studio 2022' and install it
   3. Download and install .Net Core SDK for running C# from the command line. It should be installed during the Visual Studio installation
   4. Clone project to local directory (Ex: C:\)
   5. Download and install Node.js (https://nodejs.org/en/download)
   6. If necessary, run 'npm install eslint-plugin-react@latest --save-dev' from the command line in the project root directory

### Run tests from Test Explorer in Visual Studio 2022 (Community Edition)

  1. Open 'qa-automation-coding-challenge-solutions' solution with Visual Studio
  2. Re-build the solution to ensure error free. If necessary, Open 'Nuget Package Manager' from 'Tools' menu to restore all the dependency packages
  3. Open 'Terminal' inside Visual Studio from 'View' menu
  4. Change to 'C:\qa-automation-coding-challenge\qa-automation-coding-challenge' project root directory
  5. Run 'yarn start' to launch the application server
  6. If encounter 'Cannot find module 'eslint-plugin-react-refresh'' error, re-build the project, then run 'yarn start' again
  7. Open 'Test Explorer' inside Visual Studio from 'View' menu 
  8. Click on 'Test Explorer' handle from left or right side of panel to open it
  9. Right click on the test suites, then select 'Run'
	
### Run tests from the command line (PowerShell). Notes: This option only works after successfully built the project in Vistual Studio

  1. Open a terminal (Powershell)
  2. Change to 'C:\qa-automation-coding-challenge\qa-automation-coding-challenge' project root directory 
  3. Run 'yarn start'
  4. Open another terminal
  5. Change to 'C:\qa-automation-coding-challenge\CodingChallenge.Tests' project root directory
  6. Run 'dotnet test'

