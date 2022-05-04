using Lab_AnnaP_home2.Pages;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Threading;

namespace Lab_AnnaP_home2.BusinessObject
{
    public class FilterObject
    {
        protected FilterPage _filterPage;

        public FilterObject(IWebDriver webDriver)
        {
            _filterPage = new FilterPage(webDriver);
            PageFactory.InitElements(webDriver, _filterPage);
        }

        public void SearchByKeyWord (string keyword)
        {
            _filterPage.SearchByKeyWord(keyword + Keys.Enter);
            Thread.Sleep(TimeSpan.FromSeconds(3));
        }
        
        public void SelectByBrand()
        {
            _filterPage.SelectByBrand();
        }

        public void SortByExpensive()
        {
            _filterPage.FilterByPriceDropdownClick();
            _filterPage.SortExpensive();
            _filterPage.WaitPageLoad();
            Thread.Sleep(TimeSpan.FromSeconds(2));
        }

        public  void SelectFirstItem()
        {
            _filterPage.FirstItemInList();
        }
    }
}
