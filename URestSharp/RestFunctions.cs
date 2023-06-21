using BasicSelenium.UIComponents;
using BooksSpecflow.URestModels.Requests;
using BooksSpecflow.URestModels.Responses;
using BooksSpecflow.Utils;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.URestSharp
{
    internal class RestFunctions
    {
        private Helpers helper;
        public RestFunctions()
        {
            helper = new Helpers();
        }

        public GetUserResponse GetUser(string baseUrl, string userId)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"api/users/{userId}", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;

            GetUserResponse userResponse = JsonConvert.DeserializeObject<GetUserResponse>(content);
            return userResponse;
        }

        public void ReturnBook(string baseUrl, string userId)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"api/getbook/{userId}", Method.Delete);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;
        }

        public GetUserResponse UpdateUser(string baseUrl, string userId, CreateUserRequest payload)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"api/users/{userId}", Method.Put);
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;

            GetUserResponse userResponse = JsonConvert.DeserializeObject<GetUserResponse>(content);
            return userResponse;
        }

        public CreateUserResponse[] CreateUser(string baseUrl, CreateUserRequest payload)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"api/users", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;

            CreateUserResponse[] userResponse = JsonConvert.DeserializeObject<CreateUserResponse[]>(content);
            return userResponse;
        }

        public async Task<RestResponse> CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest<CreateUserRequest>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
    }
}
