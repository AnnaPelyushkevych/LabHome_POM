using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_AnnaP_home2.Pages
{
    public class ShoppingCartPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//div[@class='cart-receipt__sum']//span[not(@class)]")]
        private IWebElement _cartReceipt;

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }
        public int FindAndGetPrice()
        {
            //var text = Driver.FindElement(By.XPath(@"//div[@class='cart-receipt__sum']//span[not(@class)]")).Text;
            var text = _cartReceipt.Text;
            Console.WriteLine($"text = {text}");
            int price = Convert.ToInt32(text);
            return price;
        }
    }
}
