using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Lab_AnnaP_home2.Pages
{
    public class FilterPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//div[@data-filter-name='producer']//input")]
        private IWebElement _searchInput;
        
        [FindsBy(How = How.XPath, Using = @"//div[@data-filter-name='producer']//ul//li[1]")]
        private IWebElement _brandName;

        [FindsBy(How = How.XPath, Using = @"//select[@class]")]
        private IWebElement _filterDropDown;

        [FindsBy(How = How.XPath, Using =  @"//option[contains(@value,'expensive')]")]
        private IWebElement _filterExpensive;

        [FindsBy(How = How.XPath, Using = @"//ul[contains(@class, 'catalog')]//li[contains(@class, 'catalog')][1]//a//span[contains(@class, 'title')]")]
        private IWebElement _firstItemInList;

        public FilterPage(IWebDriver driver) : base(driver)
        {
        }

        public void SearchByKeyWord(string keyword)
        {
            WaitElementVisible(By.XPath(@"//div[@data-filter-name='producer']//input"));
           _searchInput.SendKeys(keyword + Keys.Enter);
        }

        public void SelectByBrand()
        {
            _brandName.Click();
        }

        public void FilterByPriceDropdownClick()
        {
            _filterDropDown.Click();
        }

        public void SortExpensive()
        {
            _filterExpensive.Click();
        }

        public void FirstItemInList()
        {
            _firstItemInList.Click();
        }

    }
}
