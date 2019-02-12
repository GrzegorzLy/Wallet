using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;

namespace Wallet.Selenium
{
    [TestFixture]
    public class MainTest
    {
        public IWebDriver _driver { private set; get; }
        [SetUp]
        public void StartBrowser()
        {
            _driver = FirefoxInitialise.Init();
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }
    }

    public static class FirefoxInitialise
    {
        private static IWebDriver Driver { get; set; }
        public static IWebDriver Init()
        {
            FirefoxDriverService service = FirefoxDriverService.CreateDefaultService(@"C:\MyGeckoDriverExePath\");
            service.FirefoxBinaryPath = @"C:\Program Files\Mozilla Firefox\firefox.exe";
            FirefoxOptions options = new FirefoxOptions();
            TimeSpan time = TimeSpan.FromSeconds(10);
            Driver = new FirefoxDriver(service, options, time);
            return Driver;
        }

    }
}
