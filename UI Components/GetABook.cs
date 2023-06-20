using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.UI_Components
{
    class GetABook
    {
        public static readonly By ACCEPT_PRIVACY_POLICY_BUTTON = By.XPath("//button[.='Accept']");

        public static readonly By GET_A_BOOK_BUTTON = By.XPath("//a[.='Get a book']");

        public static readonly By GET_NEW_BOOK_BUTTON = By.XPath("//a[.='Create New']");
    }
}
