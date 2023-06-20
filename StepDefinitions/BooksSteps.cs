using BasicSelenium.UIComponents;
using BooksSpecflow.UI_Components;
using BooksSpecflow.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.StepDefinitions
{
    [Binding]
    public class BooksSteps
    {
        private readonly BaseUserActions _user;
        private readonly ScenarioContext _scenarioContext;

        public BooksSteps(BaseUserActions user, ScenarioContext scenarioContext)
        {
            _user = user;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I select tab Books")]
        public void GivenISelectTabBooks()
        {
            _user.ClicksOn(Books.ACCEPT_PRIVACY_POLICY_BUTTON);
            _user.ClicksOn(Books.BOOKS_BUTTON);
        }

        [When(@"I select specific book '([^']*)' and choose '([^']*)'")]
        public void WhenISelectSpecificBookAndChoose(string bookName, string option)
        {
            _user.ClicksOn(Books.TestUser(bookName, option));

            _scenarioContext.Add("bookName", bookName);
        }

        [Then(@"I see details book element '([^']*)'")]
        public void ThenISeeDetailsBookElement(string bookElementName)
        {
            var bookElementText = _user.Find(BooksDetailsForm.NewUser(bookElementName)).Text;
            var bookNameBooksPage = _scenarioContext["bookName"].ToString();

            Assert.AreEqual(bookElementText, bookNameBooksPage, "Name of book is incorrect!");
        }
    }
}
