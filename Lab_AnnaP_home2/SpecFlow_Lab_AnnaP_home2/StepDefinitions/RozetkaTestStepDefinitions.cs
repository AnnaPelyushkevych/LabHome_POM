using Lab_AnnaP_home2.BusinessObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;

//[assembly: Parallelizable(ParallelScope.All)]
//[assembly: LevelOfParallelism(3)]
namespace SpecFlowRozetkaTest.StepDefinitions
{
    [Binding]
    public class RozetkaTestStepDefinitions
    {
        private IWebDriver _driver;
        private HomeObject _homeObject;
        private FilterObject _filterObject;
        private ProductObject _productObject;
        private ShoppingCartObject _shoppingCartObject;

        [BeforeScenario("MyTest")]
        public void Before()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
        }

        [Given(@"User opens rozetka home page")]
        public void GivenUserOpensRozetkaHomePage()
        {
            _driver.Navigate().GoToUrl("https://rozetka.com.ua/");
        }


        [When(@"User searches '([^']*)' using search input")]
        public void GivenUserSearchesUsingSearchInput(string searchWord)
        {
            _homeObject = new HomeObject(_driver);
            _homeObject.SearchByKeyword(searchWord);
        }

        [When(@"User filters by '([^']*)'")]
        public void GivenUserFiltersBy(string brandName)
        {
            _filterObject = new FilterObject(_driver);
            _filterObject.SearchByKeyWord(brandName);
            _filterObject.SelectByBrand();
        }
        
        [When(@"User sorts products by expensive")]
        public void GivenUserSortsProductsByExpensive()
        {
            _filterObject.SortByExpensive();
        }

        [When(@"User selects first item")]
        public void GivenUserSelectsFirstItem()
        {
            _filterObject.SelectFirstItem();
        }

        [When(@"User adds product to shopping cart")]
        public void WhenUserAddsProductToShoppingCart()
        {
            _productObject = new ProductObject(_driver);
            _productObject.ClickAddToCart();
        }


        [Then(@"User checks that '([^']*)'is grater than treshhold")]
        public void ThenUserChecksThatIsGraterThanTreshhold(string threshold)
        {
            var priceToCompare = Convert.ToInt32(threshold);
            _shoppingCartObject = new ShoppingCartObject(_driver);
            //Assertion
            Assert.That(_shoppingCartObject.FindAndGetPrice(), Is.GreaterThan(priceToCompare));
        }

        [AfterScenario("MyTest")]
        public void After()
        {
            _driver.Quit();
        }
    }
}
