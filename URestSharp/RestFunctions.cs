using BooksSpecflow.URestModels.Requests;
using BooksSpecflow.Utils;
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
