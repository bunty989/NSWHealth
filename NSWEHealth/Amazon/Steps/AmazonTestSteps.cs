using NSWEHealth.Amazon.PageObjects;
using NSWEHealth.Amazon.Setup;
using NUnit.Framework;
using NSWEHealth.Framework.Drivers;
using NSWEHealth.Framework.Wrapper;
using TechTalk.SpecFlow;
using ConfigType = NSWEHealth.Framework.Wrapper.TestConstant.ConfigTypes;
using ConfigKey = NSWEHealth.Framework.Wrapper.TestConstant.ConfigTypesKey;


namespace NSWEHealth.Amazon.Steps
{
    [Binding]
    internal class AmazonTestSteps
    {
        private readonly HomePage? _homePage;
        private readonly SearchResultPage? _searchResultPage;
        private readonly DriverHelper? _driverHelper;
        private readonly CommonMethods? _commonMethods;
        private readonly ScenarioContext? _scenarioContext;
        private static string Protocol => ConfigHelper.ReadConfigValue(ConfigType.WebDriverConfig, ConfigKey.Protocol);
        private static string Url => SetAppUrl.SetUrl(Protocol);

        public AmazonTestSteps(ScenarioContext scenarioContext,
            DriverHelper driverHelper)
        {
            _driverHelper = driverHelper;
            var driver = driverHelper.Driver;
            _commonMethods = new CommonMethods();
            _scenarioContext = scenarioContext;
            _homePage = new HomePage(driver);
            _searchResultPage = new SearchResultPage(driver);
        }

        [Given(@"I open the Amazon australia home page")]
        public void GivenIOpenTheAmazonAustraliaHomePage()
        {
            _driverHelper?.Navigate(Url);
        }


        [When(@"I want to search for '([^']*)'")]
        public void WhenIWantToSearchFor(string itemName)
        {
            _scenarioContext["ItemName"] = itemName;
            _homePage?.SearchForAnItem(itemName);
        }

        [Then(@"the result shows the list of the searched item")]
        public void ThenTheResultShowsTheListOfTheSearchedItem()
        {
            var result = _searchResultPage?.GetLabelDisplayedResultFor();
            Assert.AreEqual(_scenarioContext["ItemName"], result?.Replace("\"", ""));
        }

        [When(@"I select filter for '([^']*)' as '([^']*)'")]
        public void WhenISelectFilterForAs(string filterType, string filterValue)
        {
            switch (filterType.ToLowerInvariant())
            {
                case "brand":
                {
                    _searchResultPage?.FilterByBrand(
                        (AmazonTestConstant.BrandName)Enum.Parse
                        (typeof(AmazonTestConstant.BrandName), filterValue, true));
                    break;
                }
                case "resolution":
                {
                    _searchResultPage?.FilterByResolution(filterValue);
                    break;
                }
                case "model":
                {

                    _searchResultPage?.FilterByModel(filterValue);
                    break;
                }
            }
        }

        [Then(@"I verify all the filter checkboxes are checked")]
        [Then(@"items are sorted by the price from low to high")]
        public void ThenIVerifyAllTheFilterCheckboxesAreChecked()
        {
            Assert.IsTrue(_searchResultPage?.VerifyFilteredResultListDisplayed());
        }

        [When(@"I sort the result by price low to high")]
        public void WhenISortTheResultByPriceLowToHigh()
        {
            _searchResultPage?.SortByPriceLowToHigh();
        }

    }
}
