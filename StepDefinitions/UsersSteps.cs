using BasicSelenium.UIComponents;
using BooksSpecflow.Utils;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.StepDefinitions
{
    [Binding]
    public class UsersSteps
    {
        private readonly BaseUserActions _user;
        private readonly ScenarioContext _scenarioContext;

        public UsersSteps(BaseUserActions user, ScenarioContext scenarioContext)
        {
            _user = user;
            _scenarioContext = scenarioContext;
        }

        [When(@"I select specific user '([^']*)'")]
        public void WhenISelectSpecificUser(string ergergb)
        {
            IList<IWebElement> elements = _user.FindElements(Users.TEST_USER);
            var firstResult = elements.First();

            var details = firstResult.FindElement(Users.DETAILS_ELEMENT);
            details.Click();
        }


    }
}
