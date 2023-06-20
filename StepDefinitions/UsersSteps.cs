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
            IList<IWebElement> elements = _user.FindElements(UserDetailsForm.DETAILS_ELEMENT_NAME);
            var resultUser = elements.First();

            var nameOfUserDetailsPage = resultUser.Text;
            var usernameUsersPage = _scenarioContext["username"].ToString();

            Assert.AreEqual(nameOfUserDetailsPage, usernameUsersPage, "User details are incorrect!");
        }

        [Then(@"I select delete option")]
        public void ThenISelectDeleteOption()
        {
            _user.Find(UserDeleteForm.DELETE_BUTTON);
        }

        [Then(@"I edit user")]
        public void ThenIEditUser()
        {
            _user.Find(UserEditForm.EDIT_TEXTBOX);
        }

        [Given(@"I select on create new user option")]
        public void GivenISelectOnCreateNewUserOption()
        {
            _user.ClicksOn(Users.CREATE_NEW_USER_BUTTON);
        }

        [When(@"I enter and create new user '([^']*)'")]
        public void WhenIEnterAndCreateNewUser(string newUser)
        {
            _user.WaitsUntilVisible(UserCreateForm.NAME_BOX);
            _user.WaitsUntilVisible(UserCreateForm.CREATE_USER_BUTTON);

            _user.TypesInto(UserCreateForm.NAME_BOX, newUser);
            _user.ClicksOn(UserCreateForm.CREATE_USER_BUTTON);

            _scenarioContext.Add("usernameNew", newUser);
        }

        [Then(@"I see new user '([^']*)' on users page")]
        public void ThenISeeNewUserOnUsersPage(string newUser)
        {
            var userOnUsersPage = _user.Find(Users.NewUser(newUser)).Text;
            var usernameUserCreationPage = _scenarioContext["usernameNew"].ToString();

            Assert.AreEqual(userOnUsersPage, usernameUserCreationPage, "New user is incorrect!");

        }



    }
}
