using OpenQA.Selenium;

namespace BasicSelenium.UIComponents
{
    class Users
    {
        public static readonly By ACCEPT_PRIVACY_POLICY_BUTTON = By.XPath("//button[.='Accept']");

        public static readonly By CREATE_NEW_USER_BUTTON = By.XPath("//a[.='Create New']");

        public static readonly By NAME_BOX = By.Id("Name");

        public static readonly By CREATE_USER_BUTTON = By.XPath("//input[@class='btn btn-default']");

        public static readonly By TEST_USER = By.XPath("//td[contains(text(),'ergergb')]");

        public static readonly By DETAILS_ELEMENT = By.XPath("//a[contains(text(),'Details')]");

    }
}
