using OpenQA.Selenium;
using NSWEHealth.Framework.Wrapper;
using LocatorType = NSWEHealth.Framework.Wrapper.
    TestConstant.LocatorType;
using WebDriverAction = NSWEHealth.Framework.Wrapper.
    TestConstant.WebDriverAction;


namespace NSWEHealth.Amazon.PageObjects
{
    internal class HomePage
    {
        private readonly WebHelper _webHelper;
        protected IWebElement? TxtSearch =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#twotabsearchtextbox");
        protected IWebElement? BtnSearch =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[id$='submit-button']");

        public HomePage(IWebDriver? driver) =>
            _webHelper = new WebHelper(driver);

        public void SearchForAnItem(string itemName)
        {
            EnterItemToSearch(itemName);
            ClickSubmitBtn();
        }

        private void EnterItemToSearch(string itemName)
        {
            _webHelper.PerformWebDriverAction(TxtSearch, WebDriverAction.Input,
                itemName);
        }

        private void ClickSubmitBtn()
        {
            _webHelper.PerformWebDriverAction(BtnSearch, WebDriverAction.Click,
                null);
        }
    }
}
