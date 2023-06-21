using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.URestModels.Responses
{
    public class CreateABookDetailsResponse
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int bookId { get; set; }
        public DateTime dateTaken { get; set; }
        public object book { get; set; }
        public object user { get; set; }
    }
}
