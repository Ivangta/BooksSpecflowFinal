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
        [Then(@"I select tab Books")]
        public void GivenISelectTabBooks()
        {
            if (_user.CanSee(Books.ACCEPT_PRIVACY_POLICY_BUTTON))
            {
                _user.ClicksOn(Books.ACCEPT_PRIVACY_POLICY_BUTTON);
            }

            _user.ClicksOn(Books.BOOKS_BUTTON);
        }

        [Given(@"I select specific book (.*) and choose '([^']*)'")]
        [When(@"I select specific book (.*) and choose '([^']*)'")]
        [Then(@"I select specific book (.*) and choose '([^']*)'")]
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

        [When(@"I select delete book option")]
        [Then(@"I select delete book option")]
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
            _user.WaitsUntilVisible(BooksEditCreateForm.NAME_BOX);
            _user.WaitsUntilVisible(BooksEditCreateForm.EDIT_BOOK_BUTTON);

            _user.TypesInto(BooksEditCreateForm.NAME_BOX, newBookName);
            _user.ClicksOn(BooksEditCreateForm.EDIT_BOOK_BUTTON);

            _scenarioContext.Add("bookNameNewEditing", newBookName);
        }

        [Then(@"I see book '([^']*)' is present on books page after editing")]
        public void ThenISeeBookIsPresentOnBooksPageAfterEditing(string bookEdited)
        {
            var bookEdit= _user.Find(Books.CheckBook(bookEdited)).Text;
            var bookNameBooksPage = _scenarioContext["bookNameNewEditing"].ToString();

            Assert.AreEqual(bookEdit, bookNameBooksPage, "Name of book is not edited!");
        }

        [Given(@"I select create new book option")]
        [When(@"I select create new book option")]
        public void GivenISelectCreateNewBookOption()
        {
            _user.ClicksOn(Books.CREATE_NEW_BOOK_BUTTON);
        }

        [Given(@"I enter and create new book with (.*), (.*), (.*) and (.*)")]
        [When(@"I enter and create new book with (.*), (.*), (.*) and (.*)")]
        public void WhenIEnterAndCreateNewBookWithRestJohnM_ComedyAnd(string bookName, string author, string genre, string quantity)
        {
            _user.WaitsUntilVisible(BooksEditCreateForm.NAME_BOX);
            _user.WaitsUntilVisible(BooksEditCreateForm.CREATE_BOOK_BUTTON);

            _user.TypesInto(BooksEditCreateForm.NAME_BOX, bookName);
            _user.TypesInto(BooksEditCreateForm.AUTHOR_BOX, author);
            _user.TypesInto(BooksEditCreateForm.GENRE_BOX, genre);
            _user.TypesInto(BooksEditCreateForm.QUANTITY_BOX, quantity);
            _user.ClicksOn(BooksEditCreateForm.CREATE_BOOK_BUTTON);

            _scenarioContext.Add("bookNameNewCreation", bookName);
        }

        [Given(@"I see book (.*) is present on books page after creation")]
        [Then(@"I see book (.*) is present on books page after creation")]
        public void ThenISeeBookIsPresentOnBooksPageAfterCreation(string bookCreated)
        {
            var bookCreate = _user.Find(Books.CheckBook(bookCreated)).Text;
            var bookNameBooksPage = _scenarioContext["bookNameNewCreation"].ToString();

            Assert.AreEqual(bookCreate, bookNameBooksPage, "Book is not created!");
        }

        [Given(@"I click create new book button")]
        public void GivenIClickCreateNewBookButton()
        {
            _user.WaitsUntilVisible(BooksEditCreateForm.CREATE_BOOK_BUTTON);

            _user.ClicksOn(BooksEditCreateForm.CREATE_BOOK_BUTTON);
        }

        [Given(@"I see error message for quantity")]
        public void GivenISeeErrorMessageForQuantity()
        {
            bool messageDisplayed = _user.Find(BooksEditCreateForm.ERROR_QUANTITY_MESSAGE).Displayed;

            Assert.IsTrue(messageDisplayed, "Error message for quantity is not displayed!");
        }

        [When(@"I enter and create new book with incorrect details")]
        public void WhenIEnterAndCreateNewBookWithIncorrectDetails()
        {
            _user.WaitsUntilVisible(BooksEditCreateForm.NAME_BOX);
            _user.WaitsUntilVisible(BooksEditCreateForm.CREATE_BOOK_BUTTON);

            var nameIncorrectLength = Helpers.GenerateRandomAlphanumericString(251);
            _user.TypesInto(BooksEditCreateForm.NAME_BOX, nameIncorrectLength);

            var authorIncorrectLength = Helpers.GenerateRandomAlphanumericString(101);
            _user.TypesInto(BooksEditCreateForm.AUTHOR_BOX, authorIncorrectLength);

            var genreIncorrectLength = Helpers.GenerateRandomAlphanumericString(51);
            _user.TypesInto(BooksEditCreateForm.GENRE_BOX, genreIncorrectLength);

            _user.TypesInto(BooksEditCreateForm.QUANTITY_BOX, "2");
            _user.ClicksOn(BooksEditCreateForm.CREATE_BOOK_BUTTON);
        }

        [Then(@"I validate correct error is shown")]
        public void ThenIValidateCorrectErrorIsShown()
        {
            var statement = _user.CanSeeAlert();
            Assert.AreEqual(true, statement, "No error message present!");
        }

    }
}
