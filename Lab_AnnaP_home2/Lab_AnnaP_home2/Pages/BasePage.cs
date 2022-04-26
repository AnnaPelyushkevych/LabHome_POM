using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace Lab_AnnaP_home2.Pages
{
    public class BasePage
    {
        const int _timeout = 10000;
        IWebDriver _driver;

        public IWebDriver Driver
        {
            get { return _driver; }
        }

        public BasePage(IWebDriver driver)
        {
            _driver = driver;
        }

        public void WaitPageLoad()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromMilliseconds(_timeout));
            wait.Until(drvr => ((IJavaScriptExecutor)drvr).ExecuteScript("return document.readyState").Equals("complete"));
        }

        public void WaitElementVisible(By criteria)
        {
            new WebDriverWait(_driver, TimeSpan.FromSeconds(_timeout)).Until(ExpectedConditions.ElementExists(criteria));
        }

        public void ImplicitWaitForSeconds(int seconds)
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }
    }
}
