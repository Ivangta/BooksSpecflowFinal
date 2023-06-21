using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.URestModels.Requests
{
    public class CreateABookRequest
    {
        public int userid { get; set; }
        public int bookid { get; set; }
    }

}
