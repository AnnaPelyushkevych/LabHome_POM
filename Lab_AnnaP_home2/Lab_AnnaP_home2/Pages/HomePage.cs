using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Lab_AnnaP_home2.Pages
{
    public class HomePage : BasePage
    {
        //private const string SEARCH_INPUT = @"//input[@name = 'search']";
        [FindsBy(How = How.XPath, Using = @"//input[@name = 'search']")]
        private IWebElement _searchInput;

        public HomePage(IWebDriver driver) : base(driver)
        {
            
        }

        public void SearchByKeyWord(string keyword)
        {
            _searchInput.SendKeys(keyword + Keys.Enter);
        }
    }
}
