using Lab_AnnaP_home2.Pages;
using OpenQA.Selenium;

namespace Lab_AnnaP_home2.Decorator
{
    public class DecoratedClickButton : DecoratedWebElement
    {

        public DecoratedClickButton(IWebElement _webElement) : base(_webElement)
        {
        }

        public override void Click()
        {
            base.Click();
            //try
            //{
            //    base.Click();
            //}
            //catch (ElementClickInterceptedException)
            //{
            //    //AddWaiterThanClick
            //    //base.Click();
            //}
        }
    }
}
