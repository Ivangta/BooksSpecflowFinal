using BooksSpecflow.UI_Components;
using BooksSpecflow.Utils;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BooksSpecflow.StepDefinitions
{
    [Binding]
    internal class GetABookSteps
    {
        private readonly BaseUserActions _user;
        private readonly ScenarioContext _scenarioContext;

        public GetABookSteps(BaseUserActions user, ScenarioContext scenarioContext)
        {
            _user = user;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I select tab GetABook")]
        public void GivenISelectTabGetABook()
        {
            if (_user.CanSee(Books.ACCEPT_PRIVACY_POLICY_BUTTON))
            {
                _user.ClicksOn(Books.ACCEPT_PRIVACY_POLICY_BUTTON);
            }
            
            _user.ClicksOn(GetABook.GET_A_BOOK_BUTTON);
        }

        [Given(@"I enter and get new book with (.*) and (.*)")]
        [Then(@"I enter and get new book with (.*) and (.*)")]
        public void GivenIEnterAndGetNewBookWithAndJohnS_(string userId, string bookId)
        {
            IWebElement seachUserIdDropDown = _user.Find(GetABookEditCreateForm.USERID_DROPDOWN);
            seachUserIdDropDown.Click();
            SelectElement selectUserId = new SelectElement(seachUserIdDropDown);
            selectUserId.SelectByText(userId);

            IWebElement seachBookIdDropDown = _user.Find(GetABookEditCreateForm.BOOKID_DROPDOWN);
            seachBookIdDropDown.Click();
            SelectElement selectBookId = new SelectElement(seachBookIdDropDown);
            selectBookId.SelectByText(bookId);

            _user.ClicksOn(GetABookEditCreateForm.CREATE_GET_BOOK_BUTTON);
        }

        [Then(@"I see quantity of book is '([^']*)'")]
        public void ThenISeeQuantityOfBookIs(string expectedQuantity)
        {
            IList<IWebElement> elements = _user.FindElements(BooksDetailsForm.Elements());
            var resultBook = elements.First();

            var nameOfBookDetailsPage = resultBook.Text;
            var newQuantity = Helpers.RemoveNonNumericValuesUsingRegex(nameOfBookDetailsPage);
            var newQuantityFormatted = newQuantity.Replace(".", string.Empty);

            Assert.AreEqual(expectedQuantity, newQuantityFormatted, "The quantity in books details is not correct!");
        }


    }
}
