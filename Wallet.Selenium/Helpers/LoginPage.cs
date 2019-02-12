using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Wallet.Selenium.Helpers
{
    public class LoginPage
    {
        private readonly IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "Input_Email")]
        public IWebElement Login { get; set; }

        [FindsBy(How = How.Id, Using = "Input_Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-primary")]
        public IWebElement Submit { get; set; }


        public void Start() { driver.Navigate().GoToUrl("http://localhost/Wallet/"); }



    }
}
