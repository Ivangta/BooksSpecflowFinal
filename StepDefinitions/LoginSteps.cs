using BooksSpecflow.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [When(@"I log in admin and (.*)")]
        public void WhenILogInAdminAnd(int p0)
        {
            throw new PendingStepException();
        }

        [Then(@"I am successfully logged in")]
        public void ThenIAmSuccessfullyLoggedIn()
        {
            throw new PendingStepException();
        }

    }
}
