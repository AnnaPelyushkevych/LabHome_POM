using Lab_AnnaP_home2.Decorator;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Lab_AnnaP_home2.Pages
{
    public class FilterPage : BasePage
    {
        [FindsBy(How = How.XPath, Using = @"//div[@data-filter-name='producer']//input")]
        private IWebElement _searchInput;
        protected DecoratedSearchInput DecoratedSearch
        {
            get
            {
                return new DecoratedSearchInput(_searchInput);
            }
        }

        [FindsBy(How = How.XPath, Using = @"//div[@data-filter-name='producer']//ul//li[1]")]
        private IWebElement _brandName;
        protected DecoratedClickButton ClickableBrandButton
        {
            get
            {
                return new DecoratedClickButton(_brandName);
            }
        }

        [FindsBy(How = How.XPath, Using = @"//select[@class]")]
        private IWebElement _filterDropDown;
        protected DecoratedClickButton ClickableFilterDropDown
        {
            get
            {
                return new DecoratedClickButton(_filterDropDown);
            }
        }

        [FindsBy(How = How.XPath, Using =  @"//option[contains(@value,'expensive')]")]
        private IWebElement _filterExpensive;
        protected DecoratedClickButton ClickableFilterListItem
        {
            get
            {
                return new DecoratedClickButton(_filterExpensive);
            }
        }

        [FindsBy(How = How.XPath, Using = @"//ul[contains(@class, 'catalog')]//li[contains(@class, 'catalog')][1]//a//span[contains(@class, 'title')]")]
        private IWebElement _firstItemInList;
        protected DecoratedClickButton ClickableFirstItemInList
        {
            get
            {
                return new DecoratedClickButton(_firstItemInList);
            }
        }

        public FilterPage(IWebDriver driver) : base(driver)
        {
        }

        public void SearchByKeyWord(string keyword)
        {
            WaitElementVisible(By.XPath(@"//div[@data-filter-name='producer']//input"));
            DecoratedSearch.SendKeys(keyword + Keys.Enter);
        }

        public void SelectByBrand()
        {
            ClickableBrandButton.Click();
        }

        public void FilterByPriceDropdownClick()
        {
            ClickableFilterDropDown.Click();
        }

        public void SortExpensive()
        {
            ClickableFilterListItem.Click();
        }

        public void FirstItemInList()
        {
            ClickableFirstItemInList.Click();
        }

    }
}
