using OpenQA.Selenium;

namespace Lab_AnnaP_home2.Pages
{
    public class FilterPage : BasePage
    {
        private readonly string _searchInput = @"//div[@data-filter-name='producer']//input";
        private readonly string _brandName = @"//div[@data-filter-name='producer']//ul//li[1]";
        private readonly string _filterDropDown = @"//select[@class]";
        private readonly string FILTER_EXPENSIVE = @"//option[contains(@value,'expensive')]";
        private readonly string FIRST_ITEM_IN_LIST = @"//ul[contains(@class, 'catalog')]//li[contains(@class, 'catalog')][1]//a//span[contains(@class, 'title')]";
            //@"//ul[contains(@class, 'catalog')]//li[1]//a"; 
            //@"//ul[contains(@class, 'catalog')]//li[1]";

        public FilterPage(IWebDriver driver) : base(driver)
        {
        }

        public void SearchByKeyWord(string keyword)
        {
            WaitElementVisible(By.XPath(_searchInput));
            Driver.FindElement(By.XPath(_searchInput)).SendKeys(keyword + Keys.Enter);
        }

        public void SelectByBrand()
        {
            Driver.FindElement(By.XPath(_brandName)).Click();
        }

        public void FilterByPriceDropdownClick()
        {
            Driver.FindElement(By.XPath(_filterDropDown)).Click();
        }

        public void SortExpensive()
        {
            Driver.FindElement(By.XPath(FILTER_EXPENSIVE)).Click();
        }

        public void FirstItemInList()
        {
            Driver.FindElement(By.XPath(FIRST_ITEM_IN_LIST)).Click();
        }

    }
}
