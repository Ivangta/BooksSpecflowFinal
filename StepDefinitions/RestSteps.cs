using BooksSpecflow.URestModels.Requests;
using BooksSpecflow.URestModels.Responses;
using BooksSpecflow.URestSharp;
using NUnit.Framework;
using RestSharp;

namespace BooksSpecflow.StepDefinitions
{
    [Binding]
    public class RestSteps
    {
        private const string BASE_URL = "http://qa-task.immedis.com/";
        private readonly CreateUserReq createUserReq;
        private RestResponse response;
        private CreateUserRes responses;

        public RestSteps(CreateUserReq createUserReq)
        {
            this.createUserReq = createUserReq;
        }

        [Given(@"I input name ""([^""]*)""")]
        public void GivenIInputName(string name)
        {
            createUserReq.Name = name;
        }

        [When(@"I send create user request")]
        public async void WhenISendCreateUserRequest()
        {
            var api = new RestFunctions();
            response = await api.CreateNewUser(BASE_URL, createUserReq);
        }

        [Then(@"validate user is created")]
        public void ThenValidateUserIsCreated()
        {
            var content = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(createUserReq.Name, content.name);
        }

        [Given(@"I send get user request for user '([^']*)'")]
        public void GivenISendGetUserRequestForUser(string userId)
        {
            var api = new RestFunctions();
            responses = api.GetUserr(BASE_URL, userId);
        }


        [Then(@"validate user is recieved")]
        public void ThenValidateUserIsRecieved()
        {
            var content = HandleContent.GetContent<CreateUserRes>(response);
            Assert.AreEqual(createUserReq.Name, content.name);
        }


    }
}
