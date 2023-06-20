using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace BooksSpecflow.Utils
{
    public class BaseUserActions
    {
        protected IWebDriver _currentPage;
        private WebDriverWait _wait;

        internal void OpensPage(string pageName)
        {
            _currentPage = new ChromeDriver(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            _currentPage.Manage().Window.Maximize();
            _wait = new WebDriverWait(_currentPage, TimeSpan.FromSeconds(2));
            _currentPage.Navigate().GoToUrl(pageName);
            _wait = new WebDriverWait(_currentPage, TimeSpan.FromSeconds(2));
        }

        internal string ExtractCurrentPageUrl()
        {
            var url = _currentPage.Url;
            return url;
        }

        internal IWebDriver ExtractDriver()
        {
            var driver = _currentPage;
            return driver;
        }

        internal IWebElement WaitsUntilClickable(By elementLocator)
        {
            return _wait.Until(ExpectedConditions.ElementToBeClickable(elementLocator));
        }

        internal IWebElement WaitsUntilVisible(By elementLocator)
        {
            return _wait.Until(ExpectedConditions.ElementIsVisible(elementLocator));
        }

        internal void WaitUntilNotVisible(By elementLocator)
        {
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(elementLocator));
        }

        internal void WaitUntilNotVisible(By elementLocator, TimeSpan timeout)
        {
            TimeSpan originalTimeout = _wait.Timeout;
            _wait.Timeout = timeout;

            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(elementLocator));

            _wait.Timeout = originalTimeout;
        }

        internal void ClicksOn(By elementLocator)
        {
            WaitsUntilClickable(elementLocator).Click();
        }

        internal string ReadsTextFrom(By elementLocator)
        {
            return WaitsUntilVisible(elementLocator).Text.Trim();
        }

        internal void TypesInto(By elementLocator, string text)
        {
            WaitsUntilClickable(elementLocator).Clear();
            Find(elementLocator).SendKeys(text);
        }

        internal protected IWebElement Find(By elementLocator)
        {
            return _currentPage.FindElement(elementLocator);
        }

        internal bool CanSeeAlert()
        {
            try
            {
                IAlert alrert = _currentPage.SwitchTo().Alert();
                alrert.Accept();

                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }
    }
}
