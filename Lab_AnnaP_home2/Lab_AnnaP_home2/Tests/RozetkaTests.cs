using Lab_AnnaP_home2.Helpers;
using Lab_AnnaP_home2.Pages;
using log4net;
using log4net.Config;
using log4net.Core;
using log4net.Repository;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Reflection;
using System.Threading;
using WebDriverManager.DriverConfigs.Impl;
using System.IO;

namespace Lab_AnnaP_home2.Tests
{
    [Parallelizable(ParallelScope.All)]
    public class RozetkaTests : BaseTest
    {
        [Test]
        [TestCaseSource(typeof(TestDataProvider), nameof(TestDataProvider.FiltersToTest))]
        public void MostExpensiveItemCostsMoreThanThreshold(SearchFilter filter)
        {
            log.Info("Test started with parametrs");
            log.Info($"item = {filter.ItemSearch}, brand = {filter.ItemBrand}, price = {filter.PriceToCompare}");

            try
            {
                var homePage = new HomePage(EventFiringWebDriver);
                // Add log Search on home page
                log.Info("Search on HomePage");
                homePage.SearchByKeyWord(filter.ItemSearch);
                homePage.WaitPageLoad();

                // FilterPage manipulations
                var filterPage = new FilterPage(EventFiringWebDriver);
                // Add log search on brand filter
                log.Info("Search on FilterPage");
                filterPage.SearchByKeyWord(filter.ItemBrand);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                filterPage.SelectByBrand();

                // Add log started sorting by expensive
                log.Info("Started sorting by exepensive");
                filterPage.FilterByPriceDropdownClick();
                filterPage.SortExpensive();
                filterPage.WaitPageLoad();
                Thread.Sleep(TimeSpan.FromSeconds(2));

                // Add log end of sorting
                log.Info("End of sorting");

                filterPage.FirstItemInList();
                // Add log First Item selected
                log.Info("First Item selected");
                // ProductPage manipulations
                var productPage = new ProductPage(EventFiringWebDriver);
                productPage.ImplicitWaitForSeconds(30);
                productPage.MoveToItemsListMenu();
                productPage.ClickAddToCart();

                // ShoppingCartPage manipulations
                var shoppingCartPage = new ShoppingCartPage(EventFiringWebDriver);
                Thread.Sleep(TimeSpan.FromSeconds(1));

                // Add log assertion started
                log.Info("Assertion started");
                //Assertion
                Assert.That(shoppingCartPage.FindAndGetPrice(), Is.GreaterThan(filter.PriceToCompare));
                // Add log assertion ended
                log.Info("Assertion ended");

                // Add log test finished
                log.Info("Test finished");
            }
            catch (Exception ex)
            {
                log.Error($"Test failed with this exception message {ex.Message}");
            }
        }
    }
}