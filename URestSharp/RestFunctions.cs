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

        public GetUserResponse UpdateUser(string baseUrl, string userId, CreateUserRequest payload)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"api/books/{userId}", Method.Put);
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

        public CreateBookResponse[] CreateBook(string baseUrl, CreateBookRequest payload)
        {
            var client = new RestClient(baseUrl);
            var request = new RestRequest($"api/books", Method.Post);
            request.AddHeader("Accept", "application/json");
            request.AddBody(payload);
            request.RequestFormat = DataFormat.Json;

            RestResponse response = client.Execute(request);
            var content = response.Content;

            CreateBookResponse[] bookResponse = JsonConvert.DeserializeObject<CreateBookResponse[]>(content);
            return bookResponse;
        }
    }
}
