using BasicSelenium.UIComponents;
using BooksSpecflow.Utils;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.StepDefinitions
{
    [Binding]
    public class LoginSteps
    {
        private readonly BaseUserActions _user;
        private readonly ScenarioContext _scenarioContext;

        public LoginSteps(BaseUserActions user, ScenarioContext scenarioContext)
        {
            _user = user;
            _scenarioContext = scenarioContext;
        }

        [Given(@"Homepage is open")]
        public void GivenHomepageIsOpen()
        {
            _user.OpensPage("https://qa-task.immedis.com/");
        }

        [Given(@"I log in (.*) and (.*)")]
        [When(@"I log in (.*) and (.*)")]
        public void WhenILogInAdminAnd(string username, string password)
        {
            _user.WaitsUntilVisible(Homepage.SIGN_IN_BUTTON);
            _user.WaitsUntilVisible(Homepage.SIGN_UP_BUTTON);

            _user.TypesInto(LoginForm.USERNAME_FIELD, username);
            _user.TypesInto(LoginForm.PASSWORD_FIELD, password);

            _user.ClicksOn(Homepage.SIGN_IN_BUTTON);
        }

        [Given(@"I am successfully logged in")]
        [Then(@"I am successfully logged in")]
        public void ThenIAmSuccessfullyLoggedIn()
        {
            var currentPageUrl = _user.ExtractCurrentPageUrl();
            Assert.AreEqual(currentPageUrl, "https://qa-task.immedis.com/Users", "Page Url is incorrect!");
        }

        [Then(@"Alert message pops-up")]
        public void ThenAlertMessagePops_Up()
        {
            var statement = _user.CanSeeAlert();
            Assert.AreEqual(true, statement, "No error message present!");
        }
    }
}
