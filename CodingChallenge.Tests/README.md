## Overview of test framework structure from the high level:

The 'CodingChallenge.Tests' project contains the following files:
   - SearchGithubRepoApplication.feature
   - SearchGithubRepoApplicationSteps.cs
   - SearchGithubRepoApplicationPage.cs

Descriptions:

1) Feature file has number of scenarios, and each scenario has number of steps.  These steps map to the methods in the specflow steps class.  And we can have multiple scenario steps mapping to the same method. 

2) The Specflow Steps Class file is where the methods in the specflow steps class used Selenium WebDriver API to locate elements on the html page and interact with them.

3) The Page Object File contains test codes, which it uses Selenium WebDriver API to locate HTML elements and interact with them

3) The HTML page from the 'Get Github Repos' application has number of elements

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

   - Download and install Visual Studio 2022 (Community Edition)
   - Download and install .Net Core SDK for running C# from command line
   - Clone project to local directory (Ex: C:\)
   - Download and install Node JS for Windows 10 or 11 
   - If it's necessary, run 'npm install eslint-plugin-react@latest --save-dev'

### Run tests from the command line (PowerShell)

  1. Install .Net Core SDK for C#
  2. Open a terminal (Powershell)
  3. Change to 'C:\qa-automation-coding-challenge\qa-automation-coding-challenge' project root directory 
  4. Run 'yarn start'
  5. Open another terminal
  6. Change to 'C:\qa-automation-coding-challenge\CodingChallenge.Tests' project root directory
  7. Run 'dotnet test'

### Run from Test Explorer in Visual Studio 2022 (Community Edition)

  1. Launch a 'qa-automation-coding-challenge-solutions' project in Visual Studio
  2. Re-build the solution to ensure error free. If it's necessary, Open 'Nuget Package Manager' from 'Tools' menu to restore all the dependency packages
  3. Open 'Terminal' inside Visual Studio from 'View' menu
  4. Change to 'C:\qa-automation-coding-challenge\qa-automation-coding-challenge' project root directory
  5. Run 'yarn start'
  6. Open 'Test Explorer' inside Visual Studio from 'View' menu 
  7. Click on 'Test Explorer' handle to open from left or right side of pannel
  8. Right click on the test suites, then select 'Run'
