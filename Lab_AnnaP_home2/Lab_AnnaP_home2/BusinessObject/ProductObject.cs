using Lab_AnnaP_home2.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_AnnaP_home2.BusinessObject
{
    public class ProductObject
    {
        protected ProductPage _productPage;

        public ProductObject(IWebDriver webDriver)
        {
            _productPage = new ProductPage(webDriver);
            PageFactory.InitElements(webDriver, _productPage);
        }
        public void ClickAddToCart()
        {
            _productPage.ImplicitWaitForSeconds(30);
            _productPage.MoveToItemsListMenu();
            _productPage.ClickAddToCart();
        }
    }
}
