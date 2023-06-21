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

        public CreateUserRes GetUserr(string baseUrl, string userId)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"api/users/{userId}", Method.Get);
            request.AddHeader("Accept", "application/json");
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;

            CreateUserRes userResponse = JsonConvert.DeserializeObject<CreateUserRes>(content);
            return userResponse;
        }

        public async Task<RestResponse> GetUser(string baseUrl, string userId)
        {
            var client = helper.SetUrl(baseUrl, $"api/users/{userId}");
            var request = helper.CreateGetRequest();
            request.RequestFormat = DataFormat.Json;
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
        public async Task<RestResponse> CreateNewUser(string baseUrl, dynamic payload)
        {
            var client = helper.SetUrl(baseUrl, "api/users");
            //var jsonString = HandleContent.SerializeJsonString(payload);
            var request = helper.CreatePostRequest<CreateUserReq>(payload);
            var response = await helper.GetResponseAsync(client, request);
            return response;
        }
    }
}
