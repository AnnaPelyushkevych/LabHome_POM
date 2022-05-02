using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_AnnaP_home2.Pages
{
    public class ProductPage : BasePage
    {

        [FindsBy(How = How.XPath, Using = @"//ul[@class='product-buttons']//button[contains(@class,'buy-button')]")]
        private IWebElement _buyButton;

        [FindsBy(How = How.XPath, Using = @"//ul[@class='tabs__list']")]
        private IWebElement _tablistItem;



        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAddToCart()
        {
            WaitElementVisible(By.XPath(@"//ul[@class='product-buttons']//button[contains(@class,'buy-button')]"));
            _buyButton.Click();
        }

        public void MoveToItemsListMenu()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(@"//ul[@class='tabs__list']")));

            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }
    }
}
