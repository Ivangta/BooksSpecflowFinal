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
        private GetUserResponse getUserResponse;
        private DeleteUserResponse deleteUserResponse;
        private CreateUserResponse[] createUserResponse;
        private readonly ScenarioContext _scenarioContext;
        private string _id;

        public RestSteps(CreateUserRequest createUserReq, ScenarioContext scenarioContext)
        {
            this.createUserReq = createUserReq;
            _scenarioContext = scenarioContext;
        }

        [Given(@"I input name ""([^""]*)""")]
        public void GivenIInputName(string name)
        {
            createUserReq.Name = name;
        }

        [Given(@"I update user name to ""([^""]*)""")]
        public void GivenIUpdateUserNameTo(string name)
        {
            createUserReq.Name = name;
        }

        [Given(@"I input id '([^']*)'")]
        public void GivenIInputId(string id)
        {
            _id = id;
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


        [Then(@"validate user ""([^""]*)"" is created")]
        public void ThenValidateUserIsCreated(string user)
        {
            var contentUser = _scenarioContext["createUserResponse"].ToString();
            var userName = contentUser.Contains(user);
            Assert.IsTrue(userName, "User is not created!");
        }

        [When(@"I send get user request")]
        public void GivenISendGetUserRequest()
        {
            var api = new RestFunctions();
            getUserResponse = api.GetUser(BASE_URL, _id);
            _scenarioContext.Add("getUserResponseId", getUserResponse.id);
        }

        [When(@"I send get user request for user '([^']*)'")]
        public void WhenISendGetUserRequestForUser(string userId)
        {
            var api = new RestFunctions();
            getUserResponse = api.GetUser(BASE_URL, userId);
            _scenarioContext.Add("getUserResponseName", getUserResponse.name);
        }

        [Then(@"validate '([^']*)' user is received")]
        public void ThenValidateUserIsReceived(string userId)
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




    }
}
