using BooksSpecflow.StepDefinitions;
using BooksSpecflow.Utils;
using OpenQA.Selenium;
using System;
using System.Xml.Linq;

namespace BasicSelenium.UIComponents
{
    class Users
    {
        public static readonly By ACCEPT_PRIVACY_POLICY_BUTTON = By.XPath("//button[.='Accept']");

        public static readonly By CREATE_NEW_USER_BUTTON = By.XPath("//a[.='Create New']");

        public static readonly By DETAILS_ELEMENT = By.XPath("//a[contains(text(),'Details')]");

        public static By TestUser(string element, string action)
        {
            return By.XPath($"//td[contains(text(),'{element}')]/ancestor::tr//a[.='{action}']");
        }

        public static By NewUser(string newUserName)
        {
            return By.XPath($"//td[contains(text(),'{newUserName}')]");
        }
    }
}
