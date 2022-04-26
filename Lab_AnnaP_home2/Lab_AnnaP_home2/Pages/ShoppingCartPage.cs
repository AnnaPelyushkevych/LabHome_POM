﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_AnnaP_home2.Pages
{
    public class ShoppingCartPage : BasePage
    {
        private const string CART_RECEIPTE = @"//div[@class='cart-receipt__sum']//span[not(@class)]";

        public ShoppingCartPage(IWebDriver driver) : base(driver)
        {
        }
        public int FindAndGetPrice()
        {
            int price = Convert.ToInt32(Driver.FindElement(By.XPath(CART_RECEIPTE)).Text);
            return price;
        }
    }
}
