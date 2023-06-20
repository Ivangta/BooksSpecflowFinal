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

        [When(@"I select specific user '([^']*)' and choose details")]
        public void WhenISelectSpecificUserAndChooseDetails(string userName)
        {
            IList<IWebElement> elements = _user.FindElements(Users.TestUser(userName));
            var firstResult = elements.First();

            var details = firstResult.FindElement(Users.DETAILS_ELEMENT);
            details.Click();
        }

        [Then(@"I see details element")]
        public void ThenISeeDetailsElement()
        {
            IList<IWebElement> elements = _user.FindElements(Users.DETAILS_ELEMENT_NAME);
            var result = elements.First();

            var text = result.Text;
        }

    }
}
