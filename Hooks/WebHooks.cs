using BooksSpecflow.Utils;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BasicSelenium.Hooks
{
    [Binding]
    public class WebHooks
    {
        private readonly BaseUserActions _driver;

        public WebHooks(BaseUserActions driver)
        {
            _driver = driver;
        }

        [AfterScenario]
        public void TearDownScenario()
        {
            IWebDriver driver = _driver.ExtractDriver();
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
