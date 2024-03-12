using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using TechTalk.SpecFlow;


namespace CodingChallenge.Tests
{
    [Binding]
    public class SearchGithubRepoApplicationSteps
    {
        private IWebDriver driver;
        //WebDriverWait wait;
        SearchGithubRepoApplicationPage searchGithubRepoApplicationPage;


        [Given(@"I am on the search github repos form screen")]
        public void GivenIAmOnTheSearchGithubReposFormScreen()
        {
            driver = new ChromeDriver();
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));

            driver.Manage().Window.Maximize();

            //driver.Navigate().GoToUrl("http://localhost:3000/");

            // Refactoring steps to use Page Object Model
            searchGithubRepoApplicationPage = SearchGithubRepoApplicationPage.NavigateToPage(driver);

            //IWebElement githubUserName = driver.FindElement(By.XPath("//*[@id=\"root\"]/div/main/form/div/label"));
            //IWebElement noReposStatus = driver.FindElement(By.ClassName("output-status-text"));

            // Refactoring steps to use Page Object Model
            Assert.Equal("Get Github Repos", driver.Title);
            Assert.Equal("Github Username", searchGithubRepoApplicationPage.ValidateGithubRepoUserNameLabel().Text);
            Assert.Equal("No repos", searchGithubRepoApplicationPage.ValidateNoReposStatus().Text);

        }

        [When(@"I enter a github user name of (.*)")]
        public void WhenIEnterAGithubUserNameOf(string userName)
        {
            //IWebElement githubUserName = driver.FindElement(By.Id("username"));
            //githubUserName.SendKeys(userName);

            // Refactoring steps to use Page Object Model
            searchGithubRepoApplicationPage.GithubUserName = userName;

        }

        [When(@"I submit my search repos form")]
        public void WhenISubmitMySearchReposForm()
        {
            //driver.FindElement(By.ClassName("submit")).Click();

            // Refactoring steps to use Page Object Model
            searchGithubRepoApplicationPage.SubmitSearchRepoForm();
        }

        [Then(@"I should see the search result section for kendkhong")]
        public void ThenIShouldSeeTheSearchResultSectionForKendkhong()
        {
            //IWebElement result =
            //    wait.Until(drv => drv.FindElement(By.XPath("//*[@id=\"root\"]/div/main/section[2]/div/p")));
            //string resultFound = result.Text.ToString();
            //string trimResult = resultFound.Substring(0, resultFound.Length - 8);

            // Refactoring steps to use Page Object Model
            string resultFound = searchGithubRepoApplicationPage.ResultFound;
            Assert.Equal("Found ", resultFound);
        }

        [Then(@"I should see no search result section for kenkhong")]
        public void ThenIShouldSeeNoSearchResultSectionForKenkhong()
        {
            //IWebElement result = 
            //wait.Until(drv => drv.FindElement(By.ClassName("output-status-text")));

            // Refactoring steps to use Page Object Model
            string noResult = searchGithubRepoApplicationPage.NoResult;

            Assert.Equal("No repos", noResult);
        }

        [AfterScenario]
        public void DisposeWebDriver()
        {
            driver.Dispose();
        }
    }
}
