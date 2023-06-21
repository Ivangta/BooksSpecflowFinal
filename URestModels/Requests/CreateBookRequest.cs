using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.URestModels.Requests
{
    internal class CreateBookRequest
    {      
        public string name { get; set; }
        public string author { get; set; }
        public string genre { get; set; }
        public int quontity { get; set; }
    }
}
