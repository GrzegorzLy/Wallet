using NUnit.Framework;
using Wallet.Selenium.Helpers;

namespace Wallet.Selenium
{
    public class LoginTest : MainTest
    {
        private readonly string _login = "wseiest.pl";
        private readonly string _password = "Wsei_test123";
        [Test]
        public void Login_Test()
        {
            var registerPage = new RegisterPage(_driver);
            var loginPage = new LoginPage(_driver);
            loginPage.Start();
            loginPage.Login.SendKeys(_login);
            loginPage.Password.SendKeys(_password);
            loginPage.Submit.Click();
            
            Assert.IsTrue(registerPage.Header.Displayed);
        }
    }
}
