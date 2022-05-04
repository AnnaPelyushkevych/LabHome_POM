using Lab_AnnaP_home2.Decorator;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Lab_AnnaP_home2.Pages
{
    public class HomePage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//input[@name = 'search']")]
        private IWebElement _searchInput;
        
        protected DecoratedSearchInput DecoratedSearch
        {
            get 
            {
                 return new DecoratedSearchInput(_searchInput);
            }
        }

        public HomePage(IWebDriver driver) : base(driver)
        {
            
        }

        public void SearchByKeyWord(string keyword)
        {
            // Use Decorated input insted of original WebElement
            DecoratedSearch.SendKeys(keyword + Keys.Enter);
        }
    }
}
