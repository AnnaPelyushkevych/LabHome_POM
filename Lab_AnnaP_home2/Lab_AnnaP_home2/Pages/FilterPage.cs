using OpenQA.Selenium;

namespace Lab_AnnaP_home2.Pages
{
    public class FilterPage : BasePage
    {
        private const string SEARCH_INPUT = @"//div[@data-filter-name='producer']//input";
        private const string HP_BRAND = @"//a[@data-id='HP']";
        private const string FILTER_DROPDOWN = @"//select[@class]";
        private const string FILTER_EXPENSIVE = @"//option[contains(@value,'expensive')]";
        private const string FIRST_ITEM_IN_LIST = @"//ul[contains(@class, 'catalog')]//li[1]//a"; //@"//ul[contains(@class, 'catalog')]//li[1]";
        private const string SHOPPING_CART = @"//span[starts-with(text(),' Ноутбук HP Zbook')]/parent::a/following-sibling::div//button";

        public FilterPage(IWebDriver driver) : base(driver)
        {
        }

        public void SearchByKeyWord(string keyword)
        {
            Driver.FindElement(By.XPath(SEARCH_INPUT)).SendKeys(keyword + Keys.Enter);
        }

        public void SelectedHPBrand()
        {
            Driver.FindElement(By.XPath(HP_BRAND)).Click();
        }

        public void FilterByPrice()
        {
            Driver.FindElement(By.XPath(FILTER_DROPDOWN)).Click();
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
