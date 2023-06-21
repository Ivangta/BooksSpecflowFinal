using BasicSelenium.UIComponents;
using BooksSpecflow.URestModels.Requests;
using BooksSpecflow.URestModels.Responses;
using BooksSpecflow.URestSharp;
using NUnit.Framework;
using RestSharp;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace BooksSpecflow.StepDefinitions
{
    [Binding]
    public class RestSteps
    {
        private const string BASE_URL = "http://qa-task.immedis.com/";
        private readonly CreateUserRequest createUserReq;
        private readonly CreateBookRequest createBookReq;
        private readonly CreateABookRequest takeBookReq;
        private GetUserResponse getUserResponse;
        private GetBookResponse getBookResponse;
        private CreateUserResponse[] createUserResponse;
        private CreateBookResponse[] createBookResponse;
        private CreateABookResponse[] takeABookResponse;
        private readonly ScenarioContext _scenarioContext;
        private string _userId;
        private string _bookId;

        public RestSteps(CreateUserRequest createUserReq, CreateBookRequest createBookReq, CreateABookRequest creatABookReq, ScenarioContext scenarioContext)
        {
            this.createUserReq = createUserReq;
            this.createBookReq = createBookReq;
            this.takeBookReq = creatABookReq;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I input user name ""([^""]*)""")]
        public void GivenIInputUserName(string name)
        {
            createUserReq.Name = name;
        }

        [Given(@"I update user name to ""([^""]*)""")]
        public void GivenIUpdateUserNameTo(string name)
        {
            createUserReq.Name = name;
        }

        [Given(@"I input user id '([^']*)'")]
        public void GivenIInputUserId(string id)
        {
            _userId = id;
        }

        [When(@"I send create user request")]
        public void WhenISendCreateUserRequest()
        {
            var api = new RestFunctions();
            createUserResponse = api.CreateUser(BASE_URL, createUserReq);
            _scenarioContext.Add("createUserResponse", createUserResponse);
        }

        [Given(@"I update user '([^']*)'")]
        public void GivenIUpdateUser(string userId)
        {
            var api = new RestFunctions();
            getUserResponse = api.UpdateUser(BASE_URL, userId, createUserReq);
            _scenarioContext.Add("updateUserResponseName", getUserResponse.name);
        }

        [Given(@"I update user '([^']*)' with new name ""([^""]*)""")]
        public void GivenIUpdateUserWithNewName(string p0, string ganch)
        {
            throw new PendingStepException();
        }

        [Then(@"I validate user ""([^""]*)"" is created")]
        public void ThenIValidateUserIsCreated(string user)
        {
            var contentUser = _scenarioContext["createUserResponse"].ToString();
            var userName = contentUser.Contains(user);
            Assert.IsTrue(userName, "User is not created!");
        }

        [When(@"I send get user request")]
        public void GivenISendGetUserRequest()
        {
            var api = new RestFunctions();
            getUserResponse = api.GetUser(BASE_URL, _userId);
            _scenarioContext.Add("getUserResponseId", getUserResponse.id);
        }

        [When(@"I send get user request for user '([^']*)'")]
        public void WhenISendGetUserRequestForUser(string userId)
        {
            var api = new RestFunctions();
            getUserResponse = api.GetUser(BASE_URL, userId);
            _scenarioContext.Add("getUserResponseName", getUserResponse.name);
        }

        [Then(@"I validate '([^']*)' user is received")]
        public void ThenIValidateUserIsReceived(string userId)
        {
            var contentUser = _scenarioContext["getUserResponseId"].ToString();
            var userIdFromResponse = contentUser;
            Assert.AreEqual(userIdFromResponse, userId, "User id is not the same!");
        }

        [Then(@"I validate user is updated successfully")]
        public void ThenIValidateUserIsUpdatedSuccessfully()
        {
            var updateUserName = _scenarioContext["updateUserResponseName"].ToString();
            var getUserName = _scenarioContext["getUserResponseName"].ToString();
            Assert.AreEqual(updateUserName, getUserName, "User id is not the same!");
        }

        [Given(@"I input book name ""([^""]*)""")]
        public void GivenIInputBookName(string bookName)
        {
            createBookReq.name = bookName;
        }

        [Given(@"I input book to take (.*), (.*)")]
        public void GivenIInputBookToTakeUserId(int userId, int bookId)
        {
            takeBookReq.userid = userId;
            takeBookReq.bookid = bookId;
        }

        [Given(@"I input book (.*), (.*), (.*), (.*)")]
        public void GivenIInputBookOceanJohnS_Action(string name, string author, string genre, int quantity)
        {
            createBookReq.name = name;
            createBookReq.author = author;
            createBookReq.genre = genre;
            createBookReq.quontity = quantity;
        }

        [When(@"I send create book request")]
        public void WhenISendCreateBookRequest()
        {
            var api = new RestFunctions();
            createBookResponse = api.CreateBook(BASE_URL, createBookReq);
            _scenarioContext.Add("createBookResponse", createBookResponse);
        }

        [Then(@"I validate book ""([^""]*)"" is created")]
        public void ThenIValidateBookIsCreated(string book)
        {
            var contentUser = _scenarioContext["createBookResponse"].ToString();
            var bookName = contentUser.Contains(book);
            Assert.IsTrue(bookName, "Book is not created!");
        }

        [Given(@"I input book id '([^']*)'")]
        public void GivenIInputBookId(string id)
        {
            _bookId = id;
        }

        [When(@"I send get book request")]
        public void WhenISendGetBookRequest()
        {
            var api = new RestFunctions();
            getBookResponse = api.GetBook(BASE_URL, _bookId);
            _scenarioContext.Add("getBookResponseId", getBookResponse.id);
        }

        [Given(@"I send get book request for book id '([^']*)' to check quantity before change")]
        public void GivenISendGetBookRequestForBookIdToCheckQuantityBeforeChange(string bookId)
        {
            var api = new RestFunctions();
            getBookResponse = api.GetBook(BASE_URL, bookId);
            _scenarioContext.Add("getBookResponseIdQuantityBefore", getBookResponse.quontity);
        }

        [When(@"I send get book request for book id '([^']*)' to check quantity after change")]
        public void WhenISendGetBookRequestForBookIdToCheckQuantityAfterChange(string bookId)
        {
            var api = new RestFunctions();
            getBookResponse = api.GetBook(BASE_URL, bookId);
            _scenarioContext.Add("getBookResponseIdQuantityAfter", getBookResponse.quontity);
        }

        [Then(@"I validate '([^']*)' book id is received")]
        public void ThenIValidateBookIdIsReceived(string bookId)
        {
            var contentUser = _scenarioContext["getBookResponseId"].ToString();
            var bookIdFromResponse = contentUser;
            Assert.AreEqual(bookIdFromResponse, bookId, "Book id is not the same!");
        }

        [When(@"I send take book request")]
        public void WhenISendTakeBookRequest()
        {
            var api = new RestFunctions();
            takeABookResponse = api.TakeBook(BASE_URL, takeBookReq);
        }

        [Then(@"I validate '([^']*)' book id quantity has decreased")]
        public void ThenIValidateBookIdQuantityHasDecreased(string bookId)
        {
            var quantityOfBookBefore = _scenarioContext["getBookResponseIdQuantityBefore"].ToString();
            var quantityOfBookAfter = _scenarioContext["getBookResponseIdQuantityAfter"].ToString();
            int quantityBefore = int.Parse(quantityOfBookBefore);
            int quantityAfter = int.Parse(quantityOfBookAfter);
            Assert.That(quantityBefore == quantityAfter - 1, "Quantity has not deceased with one!");
        }



    }
}
