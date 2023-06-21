using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.URestModels.Responses
{
    public class DeleteUserResponse
    {
        public int id { get; set; }
        public string name { get; set; }
        public object[] booksTaken { get; set; }
    }
}
