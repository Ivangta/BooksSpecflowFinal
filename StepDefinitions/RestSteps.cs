using BasicSelenium.UIComponents;
using BooksSpecflow.URestModels.Requests;
using BooksSpecflow.URestModels.Responses;
using BooksSpecflow.URestSharp;
using NUnit.Framework;
using RestSharp;
using TechTalk.SpecFlow;

namespace BooksSpecflow.StepDefinitions
{
    [Binding]
    public class RestSteps
    {
        private const string BASE_URL = "http://qa-task.immedis.com/";
        private readonly CreateUserRequest createUserReq;
        private GetUserResponse getUserResponse;
        private CreateUserResponse[] createUserResponse;
        private readonly ScenarioContext _scenarioContext;

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

        [When(@"I send create user request")]
        public void WhenISendCreateUserRequest()
        {
            var api = new RestFunctions();
            createUserResponse = api.CreateUser(BASE_URL, createUserReq);
            _scenarioContext.Add("createUserResponse", createUserResponse);
        }

        [Then(@"validate user ""([^""]*)"" is created")]
        public void ThenValidateUserIsCreated(string user)
        {
            var contentUser = _scenarioContext["createUserResponse"].ToString();
            var userName = contentUser.Contains(user);
            Assert.IsTrue(userName, "User is not created!");
        }



        [When(@"I send get user request for user '([^']*)'")]
        public void GivenISendGetUserRequestForUser(string userId)
        {
            var api = new RestFunctions();
            getUserResponse = api.GetUser(BASE_URL, userId);
            _scenarioContext.Add("getUserResponseName", getUserResponse.id);
        }

        [Then(@"validate '([^']*)' user is received")]
        public void ThenValidateUserIsReceived(string userId)
        {
            var contentUser = _scenarioContext["getUserResponseName"].ToString();
            var userIdFromResponse = contentUser;
            Assert.AreEqual(userIdFromResponse, userId, "User id is not the same!");
        }



    }
}
