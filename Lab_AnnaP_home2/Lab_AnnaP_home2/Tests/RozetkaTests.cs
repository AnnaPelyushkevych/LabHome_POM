using Lab_AnnaP_home2.BusinessObject;
using Lab_AnnaP_home2.Helpers;
using NUnit.Framework;
using System;

namespace Lab_AnnaP_home2.Tests
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture]
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
                var homeSearchObject = new HomeObject(EventFiringWebDriver);
                homeSearchObject.SearchByKeyword(filter.ItemSearch);

                var filterObject = new FilterObject(EventFiringWebDriver);
                filterObject.SearchByKeyWord(filter.ItemBrand);
                filterObject.SelectByBrand();
                filterObject.SortByExpensive();  
                filterObject.SelectFirstItem();
                
                var productObject = new ProductObject(EventFiringWebDriver);
                productObject.ClickAddToCart();

                var shoppingCartObject = new ShoppingCartObject(EventFiringWebDriver);
                //Assertion
                Assert.That(shoppingCartObject.FindAndGetPrice(), Is.GreaterThan(filter.PriceToCompare));
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