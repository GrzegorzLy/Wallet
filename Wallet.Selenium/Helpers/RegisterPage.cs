using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wallet.Selenium.Helpers
{
    public class RegisterPage
    {
        private readonly IWebDriver driver;
        public RegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.CssSelector, Using = "input#Input_Email")]
        public IWebElement Email { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#Input_Password")]
        public IWebElement Password { get; set; }

        [FindsBy(How = How.CssSelector, Using = "input#Input_ConfirmPassword")]
        public IWebElement ConfirmPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "button.btn.btn-primary")]
        public IWebElement Submit { get; set; }


        [FindsBy(How = How.CssSelector, Using = "h3")]
        public IWebElement Header { get; set; }

    }
}
