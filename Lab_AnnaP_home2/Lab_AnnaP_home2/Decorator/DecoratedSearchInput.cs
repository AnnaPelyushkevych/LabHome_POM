﻿using Lab_AnnaP_home2.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_AnnaP_home2.Decorator
{
    public class DecoratedSearchInput : DecoratedWebElement
    {
        public DecoratedSearchInput(IWebElement _webElement) : base(_webElement)
        {

        }

        public override void SendKeys(string keys)
        {
            base.Clear();
            base.SendKeys(keys);
        }
    }
}
