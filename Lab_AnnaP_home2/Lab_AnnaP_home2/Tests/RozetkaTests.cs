using Lab_AnnaP_home2.Helpers;
using Lab_AnnaP_home2.Pages;
using NUnit.Framework;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

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
                PageFactory.InitElements(EventFiringWebDriver, homePage);
                log.Info("Search on HomePage");
                homePage.SearchByKeyWord(filter.ItemSearch);
                homePage.WaitPageLoad();

                var filterPage = new FilterPage(EventFiringWebDriver);
                PageFactory.InitElements(EventFiringWebDriver, filterPage);
                log.Info("Search on FilterPage");
                filterPage.SearchByKeyWord(filter.ItemBrand);
                Thread.Sleep(TimeSpan.FromSeconds(3));
                filterPage.SelectByBrand();

                log.Info("Started sorting by exepensive");
                filterPage.FilterByPriceDropdownClick();
                filterPage.SortExpensive();
                filterPage.WaitPageLoad();
                Thread.Sleep(TimeSpan.FromSeconds(2));
                log.Info("End of sorting");

                filterPage.FirstItemInList();
                log.Info("First Item selected");
                
                // ProductPage manipulations
                var productPage = new ProductPage(EventFiringWebDriver);
                PageFactory.InitElements(EventFiringWebDriver, productPage);
                productPage.ImplicitWaitForSeconds(30);
                productPage.MoveToItemsListMenu();
                productPage.ClickAddToCart();

                // ShoppingCartPage manipulations
                var shoppingCartPage = new ShoppingCartPage(EventFiringWebDriver);
                PageFactory.InitElements(EventFiringWebDriver, shoppingCartPage);
                Thread.Sleep(TimeSpan.FromSeconds(1));

                //Assertion
                Assert.That(shoppingCartPage.FindAndGetPrice(), Is.GreaterThan(filter.PriceToCompare));
                log.Info("Assertion successfully completed");

                log.Info("Test finished");
            }
            catch (Exception ex)
            {
                log.Error($"Test failed with this exception message {ex.Message}");
            }
        }
    }
}