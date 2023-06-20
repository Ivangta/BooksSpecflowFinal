using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.UI_Components
{
    class GetABookEditCreateForm
    {
        public static readonly By USERID_DROPDOWN = By.Id("UserId");

        public static readonly By BOOKID_DROPDOWN = By.Id("BookId");

        public static readonly By CREATE_GET_BOOK_BUTTON = By.XPath("//input[@value='Create']");
    }
}
