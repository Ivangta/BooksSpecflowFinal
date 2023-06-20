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

        [Given(@"I select specific book '([^']*)' and choose '([^']*)'")]
        [When(@"I select specific book '([^']*)' and choose '([^']*)'")]
        public void WhenISelectSpecificBookAndChoose(string bookName, string option)
        {
            _user.ClicksOn(Books.TestBook(bookName, option));

            _scenarioContext.Add("bookName", bookName);
        }

        [Then(@"I see details book element '([^']*)'")]
        public void ThenISeeDetailsBookElement(string bookElementName)
        {
            var bookElementText = _user.Find(BooksDetailsForm.NewBook(bookElementName)).Text;
            var bookNameBooksPage = _scenarioContext["bookName"].ToString();

            Assert.AreEqual(bookElementText, bookNameBooksPage, "Name of book is incorrect!");
        }

        [When(@"I select delete option")]
        public void WhenISelectDeleteOption()
        {
            _user.ClicksOn(BooksDeleteForm.DELETE_BUTTON);
        }

        [Then(@"I see book '([^']*)' is not present on books page")]
        public void ThenISeeBookIsNotPresentOnBooksPage(string bookName)
        {
            bool isBookPresent = _user.CanSee(Books.CheckBook(bookName));

            Assert.IsFalse(isBookPresent, "Book is not deleted!");
        }

        [When(@"I edit book to name '([^']*)'")]
        public void WhenIEditBookToName(string newBookName)
        {
            _user.WaitsUntilVisible(BooksCreateForm.NAME_BOX);
            _user.WaitsUntilVisible(BooksCreateForm.EDIT_BOOK_BUTTON);

            _user.TypesInto(BooksCreateForm.NAME_BOX, newBookName);
            _user.ClicksOn(BooksCreateForm.EDIT_BOOK_BUTTON);

            _scenarioContext.Add("bookNameNew", newBookName);
        }

        [Then(@"I see book '([^']*)' is present on books page")]
        public void ThenISeeBookIsPresentOnBooksPage(string bookEdited)
        {
            var bookEdit= _user.Find(Books.CheckBook(bookEdited)).Text;
            var bookNameBooksPage = _scenarioContext["bookNameNew"].ToString();

            Assert.AreEqual(bookEdit, bookNameBooksPage, "Name of book is not edited!");
        }


    }
}
