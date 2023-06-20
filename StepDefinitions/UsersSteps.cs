using BasicSelenium.UIComponents;
using BooksSpecflow.UI_Components;
using BooksSpecflow.Utils;
using NUnit.Framework;
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

            _scenarioContext.Add("username", userName);
        }

        [Then(@"I see details element")]
        public void ThenISeeDetailsElement()
        {
            IList<IWebElement> elements = _user.FindElements(Users.DETAILS_ELEMENT_NAME);
            var resultUser = elements.First();

            var nameOfUserDetailsPage = resultUser.Text;
            var usernameUsersPage = _scenarioContext["username"].ToString();

            Assert.AreEqual(nameOfUserDetailsPage, usernameUsersPage, "User details are incorrect!");
        }

        [Then(@"I select delete option")]
        public void ThenISelectDeleteOption()
        {
            _user.Find(DeleteUserForm.DELETE_BUTTON);
        }

        [Then(@"I edit user")]
        public void ThenIEditUser()
        {
            _user.Find(EditUserForm.EDIT_TEXTBOX);
        }



    }
}
