using log4net;
using log4net.Config;
using log4net.Repository;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.Events;
using System;
using System.IO;
using System.Reflection;
using WebDriverManager.DriverConfigs.Impl;

[assembly: LevelOfParallelism(3)]
namespace Lab_AnnaP_home2.Tests
{
    [TestFixture]
    [FixtureLifeCycle(LifeCycle.InstancePerTestCase)]
    public class BaseTest
    {
        private IWebDriver _driver;
        protected static readonly ILog log = LogManager.GetLogger(typeof(RozetkaTests));
        private static readonly ILoggerRepository repository = LogManager.GetRepository(Assembly.GetCallingAssembly());

        private EventFiringWebDriver _eventFiringWebDriver;
        public EventFiringWebDriver EventFiringWebDriver { get { return _eventFiringWebDriver; } }
        public IWebDriver Driver { get { return _driver; } }

        [SetUp]
        public void Setup()
        {
            // Addd log info setup started
            var fileInfo = new FileInfo(@"Log4net.config");
            XmlConfigurator.Configure(repository, fileInfo);
            BasicConfigurator.Configure();

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            _driver = new ChromeDriver();
            _eventFiringWebDriver = new EventFiringWebDriver(_driver);
            _eventFiringWebDriver.ElementClicked += FiringDriver_ElementClicked;

            _eventFiringWebDriver.Manage().Window.Maximize();
            _eventFiringWebDriver.Navigate().GoToUrl("https://rozetka.com.ua/");
            
            log.Info("Setup Configured");
        }

        private void FiringDriver_ElementClicked(object? sender, WebElementEventArgs e)
        {
            if (sender != null)
            {
                var type = e.Element.GetType();
                if (type !=null)
                {
                    log.Info($"Element {type.Name} Clicked");
                }
            }
            
        }

        [TearDown]
        public void TearDown()
        {
            // Add log info that Test is ended
            log.Info("Closing driver");
            _driver.Quit();
        }
    }
}
