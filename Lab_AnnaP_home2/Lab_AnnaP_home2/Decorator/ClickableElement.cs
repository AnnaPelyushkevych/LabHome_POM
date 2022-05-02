using Lab_AnnaP_home2.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_AnnaP_home2.Decorator
{
    internal class ClickableElement : DecoratedWebElement
    {

        public ClickableElement(WebElement _webElement) : base(_webElement)
        {
        }

        public override void Click()
        {
            try
            {
                base.Click();
            }
            catch (ElementClickInterceptedException)
            {
                base.Click();
            }
        }
    }
}
