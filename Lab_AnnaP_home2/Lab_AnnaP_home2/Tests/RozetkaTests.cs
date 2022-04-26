using Lab_AnnaP_home2.Helpers;
using Lab_AnnaP_home2.Pages;
using log4net;
using log4net.Config;
using log4net.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;

namespace Lab_AnnaP_home2
{
    public class Tests
    {
        private IWebDriver _driver;
        private RozetkaFilters _filters;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [SetUp]
        public void Setup()
        {
            _filters = RozetkaFiltersJsonReader.GetFiltersObjectFromJson();
            BasicConfigurator.Configure();

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _driver.Navigate().GoToUrl("https://rozetka.com.ua/");
        }

        [TearDown]
        public void TeerDown()
        {
            _driver.Close();
        }

        [Test]
        public void MostExpensiveLaptopCostsMoreThanThreshold()
        {
            // HomePage manipulations
            var homePage = new HomePage(_driver);
            homePage.SearchByKeyWord(_filters.LaptopSearch);

            // FilterPage manipulations
            var filterPage = new FilterPage(_driver);
            filterPage.SearchByKeyWord(_filters.LaptopBrand);
            filterPage.SelectedHPBrand();
            filterPage.FilterByPrice();
            filterPage.SortExpensive();
            filterPage.WaitPageLoad();
            Thread.Sleep(TimeSpan.FromSeconds(3));
            filterPage.FirstItemInList();

            // ProductPage manipulations
            var productPage = new ProductPage(_driver);
            productPage.ImplicitWaitForSeconds(3);
            productPage.MoveToItemsListMenu();
            productPage.ImplicitWaitForSeconds(3);
            productPage.ClickAddToCart();

            // ShoppingCartPage manipulations
            var shoppingCartPage = new ShoppingCartPage(_driver);
            shoppingCartPage.WaitPageLoad();

            //Assertion
            Assert.That(shoppingCartPage.FindAndGetPrice(), Is.GreaterThan(_filters.PriceToCompare));
        }
    }
}