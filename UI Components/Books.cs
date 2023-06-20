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
        public static readonly By ACCEPT_PRIVACY_POLICY_BUTTON = By.XPath("//button[.='Accept']");

        public static readonly By BOOKS_BUTTON = By.XPath("//a[.='Books']");

        public static readonly By CREATE_NEW_BOOK_BUTTON = By.XPath("//a[.='Create New']");

        public static By TestBook(string element, string action)
        {
            return By.XPath($"//td[contains(text(),'{element}')]/ancestor::tr//a[.='{action}']");
        }

        public static By CheckBook(string bookName)
        {
            return By.XPath($"//td[contains(text(),'{bookName}')]");
        }
    }
}
