using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Wallet.Selenium.Helpers
{
    public class MenuPage
    {
        private readonly IWebDriver driver;
        public MenuPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Register")]
        public IWebElement RegisterLink { get; set; }

        public void Start() { driver.Navigate().GoToUrl("http://localhost/Wallet/"); }

    }
}
