using OpenQA.Selenium;
using NSWEHealth.Framework.Wrapper;
using LocatorType = NSWEHealth.Framework.Wrapper.
    TestConstant.LocatorType;
using WebDriverAction = NSWEHealth.Framework.Wrapper.
    TestConstant.WebDriverAction;
using BrandName = NSWEHealth.Amazon.AmazonTestConstant.
    BrandName;


namespace NSWEHealth.Amazon.PageObjects
{
    internal class SearchResultPage
    {
        private readonly WebHelper _webHelper;
        protected IWebElement? LabelSearchResult =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[class$='top-small'] span[class]");
        protected IWebElement? BtnSearch =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[id$='submit-button']");
        protected IWebElement? ChkBoxBrandSony =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[aria-label='Sony'] span div label i");
        protected IWebElement? ChkBoxResolution4K =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[aria-label='4K'] span div label i");
        protected IWebElement? ChkBoxModel2022 =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[aria-label='2022'] span div label i");
        protected IWebElement? DrpDownSortBy =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[aria-label='Sort by:'] span span");
        protected IWebElement? LabelLowToHigh =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "#s-result-sort-select_1");
        protected IWebElement? ImgSonyTv =>
            _webHelper.InitialiseDynamicWebElement(LocatorType.CssSelector,
                "[alt$='(KD55X75K)']");

        public SearchResultPage(IWebDriver? driver) =>
            _webHelper = new WebHelper(driver);

        public string GetLabelDisplayedResultFor()
         => _webHelper?.ReturnVisibleText(LabelSearchResult);

        public void FilterByBrand(BrandName brandName)
        {
            var brandElement = brandName switch
            {
                BrandName.Sony => ChkBoxBrandSony,
                _ => null
            };
            _webHelper?.PerformWebDriverAction(brandElement, WebDriverAction.Click, null);
        }

        public void FilterByResolution(string resolution)
        {
            var resolutionElement = resolution switch
            {
                AmazonTestConstant.Resolution.FourK => ChkBoxResolution4K,
                _ => null
            };
            _webHelper?.PerformWebDriverAction(resolutionElement, WebDriverAction.Click, null);
        }

        public void FilterByModel(string model)
        {
            var modelElement = model switch
            {
                AmazonTestConstant.Model.TwentyTwentyTwo => ChkBoxModel2022,
                _ => null
            };
            _webHelper?.PerformWebDriverAction(modelElement, WebDriverAction.Click, null);
        }

        public bool VerifyFilteredResultListDisplayed() =>
            WebHelper.IsElementDisplayed(ChkBoxModel2022);

        public void SortByPriceLowToHigh()
        {
            _webHelper.PerformWebDriverAction(DrpDownSortBy, WebDriverAction.Click, null);
            _webHelper.PerformWebDriverAction(LabelLowToHigh, WebDriverAction.Focus, null);
            _webHelper.PerformWebDriverAction(LabelLowToHigh, WebDriverAction.Click, null);
        }
    }
}
