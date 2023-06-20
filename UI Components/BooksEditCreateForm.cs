using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.UI_Components
{
    class BooksEditCreateForm
  
    {
        public static readonly By NAME_BOX = By.Id("Name");

        public static readonly By AUTHOR_BOX = By.Id("Author");

        public static readonly By GENRE_BOX = By.Id("Genre");

        public static readonly By QUANTITY_BOX = By.Id("Quontity");

        public static readonly By CREATE_BOOK_BUTTON = By.XPath("//input[@value='Create']");

        public static readonly By EDIT_BOOK_BUTTON = By.XPath("//input[@value='Save']");
    }
}
