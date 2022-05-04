using Lab_AnnaP_home2.Decorator;
using Lab_AnnaP_home2.Helpers;
using Lab_AnnaP_home2.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_AnnaP_home2.BusinessObject
{
    public class HomeObject
    {
        protected HomePage _homePage;

        public HomeObject(IWebDriver webDriver)
        {
            _homePage = new HomePage(webDriver);
            PageFactory.InitElements(webDriver, _homePage);
        }

        public void SearchByKeyword (string keyword)
        {
            _homePage.SearchByKeyWord(keyword + Keys.Enter);
            _homePage.WaitPageLoad();
        }
    }
}
