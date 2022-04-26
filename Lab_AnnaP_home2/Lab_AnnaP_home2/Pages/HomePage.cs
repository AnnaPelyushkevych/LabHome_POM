using OpenQA.Selenium;

namespace Lab_AnnaP_home2.Pages
{
    public class HomePage : BasePage
    {
        private const string SEARCH_INPUT = @"//input[@name = 'search']";

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public void SearchByKeyWord(string keyword)
        {
            Driver.FindElement(By.XPath(SEARCH_INPUT)).SendKeys(keyword + Keys.Enter);
        }
    }
}
