using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksSpecflow.UI_Components
{
    class BooksDetailsForm
    {
        public static By NewUser(string bookElementName)
        {
            return By.XPath($"//dd[contains(text(),'{bookElementName}')]");
        }
    }
}
