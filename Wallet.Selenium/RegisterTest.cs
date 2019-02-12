using NUnit.Framework;
using Wallet.Selenium.Helpers;

namespace Wallet.Selenium
{
    public class RegisterTest: MainTest 
    {
        private readonly string _login = "wsei@test.pl";
        private readonly string _password = "Wsei_test123";
        [Test]
        public void Register_Test()
        {
            var loginPage = new LoginPage(_driver);
            var menuPage = new MenuPage(_driver);
            menuPage.Start();
            menuPage.RegisterLink.Click();
            var registerPage = new RegisterPage(_driver);
            registerPage.Email.SendKeys(_login);
            registerPage.Password.SendKeys(_password);
            registerPage.ConfirmPassword.SendKeys(_password);
            registerPage.Submit.Click();
            Assert.IsTrue(registerPage.Header.Displayed);        
            Assert.AreEqual(" Add your Budget:", registerPage.Header.Text);
        }
    }
}
