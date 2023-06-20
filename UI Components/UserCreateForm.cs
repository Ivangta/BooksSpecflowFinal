using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.UI_Components
{
    class UserCreateForm
    {
        public static readonly By NAME_BOX = By.Id("Name");

        public static readonly By CREATE_USER_BUTTON = By.XPath("//input[@class='btn btn-default']");
    }
}
