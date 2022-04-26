using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
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
        private const string BUY_BUTTON = @"//ul[@class='product-buttons']//button[contains(@class,'buy-button')]";

        private const string TABSLIST_ITEM = @"//ul[@class='tabs__list']";

        public ProductPage(IWebDriver driver) : base(driver)
        {
        }

        public void ClickAddToCart()
        {
            WaitElementVisible(By.XPath(BUY_BUTTON));
            Driver.FindElement(By.XPath(BUY_BUTTON)).Click();
        }

        public void MoveToItemsListMenu()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(TABSLIST_ITEM)));

            Actions action = new Actions(Driver);
            action.MoveToElement(element).Perform();
        }
    }
}
