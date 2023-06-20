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

        [When(@"I select specific user '([^']*)' and choose '([^']*)'")]
        public void WhenISelectSpecificUserAndChooseDetails(string userName, string option)
        {
            _user.ClicksOn(Users.TestUser(userName, option));
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
