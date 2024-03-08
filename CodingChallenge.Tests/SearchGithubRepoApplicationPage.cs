using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Tests
{
    public class SearchGithubRepoApplicationPage
    {
        private readonly IWebDriver driver;
        private const string PageUrl = "http://localhost:3000/";
        WebDriverWait wait;
        public SearchGithubRepoApplicationPage(IWebDriver driver) 
        { 
            this.driver = driver;
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        public static SearchGithubRepoApplicationPage NavigateToPage(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(PageUrl);

            return new SearchGithubRepoApplicationPage(driver);
        }

        public string GithubUserName
        {  
            set 
            {
                driver.FindElement(By.Id("username")).SendKeys(value);
            }
        }

        public string ResultFound
        {
            get
            {
                IWebElement result =
                    wait.Until(drv => drv.FindElement(By.XPath("//*[@id=\"root\"]/div/main/section[2]/div/p")));
                string resultFound = result.Text.ToString();
                string trimResult = resultFound.Substring(0, resultFound.Length - 8);

                return trimResult;
            }
        }

        public string NoResult
        {
            get
            {
                IWebElement noResult =
                    wait.Until(drv => drv.FindElement(By.ClassName("output-status-text")));

                return noResult.Text.ToString();
            }
        }

        public IWebElement ValidateGithubRepoUserNameLabel() => driver.FindElement(By.XPath("//*[@id=\"root\"]/div/main/form/div/label"));
        public IWebElement ValidateNoReposStatus() => driver.FindElement(By.ClassName("output-status-text"));
        public SearchGithubRepoApplicationPage SubmitSearchRepoForm()
        {
            driver.FindElement(By.ClassName("submit")).Click();

            return new SearchGithubRepoApplicationPage(driver);
        }
    }
}
