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
        public static By NewBook(string bookElementName)
        {
            return By.XPath($"//dd[contains(text(),'{bookElementName}')]");
        }

        public static By Elements()
        {
            return By.XPath("//dl[@class='dl-horizontal']");
        }
    }
}
