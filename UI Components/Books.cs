using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.UI_Components
{
    class Books
    {
        public static readonly By BOOKS_BUTTON = By.Id("//a[.='Books']");

        public static readonly By CREATE_NEW_BOOK_BUTTON = By.Id("//a[.='Create New']");

        public static By TestUser(string element, string action)
        {
            return By.XPath($"//td[contains(text(),'{element}')]/ancestor::tr//a[.='{action}']");
        }

        public static By NewUser(string newBookName)
        {
            return By.XPath($"//td[contains(text(),'{newBookName}')]");
        }
    }
}
