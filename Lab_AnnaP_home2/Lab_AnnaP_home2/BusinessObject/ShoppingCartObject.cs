using Lab_AnnaP_home2.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lab_AnnaP_home2.BusinessObject
{
    public class ShoppingCartObject
    {
        protected ShoppingCartPage _shoppingCartPage;

        public ShoppingCartObject(IWebDriver webDriver)
        {
            _shoppingCartPage = new ShoppingCartPage(webDriver);
            PageFactory.InitElements(webDriver, _shoppingCartPage);
        }

        public int FindAndGetPrice()
        {
            return _shoppingCartPage.FindAndGetPrice();
        } 
    }
}
