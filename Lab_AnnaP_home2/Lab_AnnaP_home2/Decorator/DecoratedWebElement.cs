using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_AnnaP_home2.Pages
{
    public class DecoratedWebElement : IWebElement
    {
        protected WebElement webElement;

        public DecoratedWebElement(WebElement _webElement)
        {
            webElement = _webElement;
        }
        public string TagName => throw new NotImplementedException();

        public string Text => throw new NotImplementedException();

        public bool Enabled => throw new NotImplementedException();

        public bool Selected => throw new NotImplementedException();

        public Point Location => throw new NotImplementedException();

        public Size Size => throw new NotImplementedException();

        public bool Displayed => throw new NotImplementedException();

        public virtual void Clear()
        {
            webElement.Clear();
        }

        public virtual void Click()
        {
            webElement.Click();
        }

        public IWebElement FindElement(By by)
        {
            throw new NotImplementedException();
        }

        public ReadOnlyCollection<IWebElement> FindElements(By by)
        {
            throw new NotImplementedException();
        }

        public string GetAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetCssValue(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetDomAttribute(string attributeName)
        {
            throw new NotImplementedException();
        }

        public string GetDomProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public string GetProperty(string propertyName)
        {
            throw new NotImplementedException();
        }

        public ISearchContext GetShadowRoot()
        {
            throw new NotImplementedException();
        }

        public virtual void SendKeys(string text)
        {
        
        }

        public void Submit()
        {
            throw new NotImplementedException();
        }
    }
}
