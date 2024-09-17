using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace C_SeleniumSelfFramework.pageObjects
{
    public class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "username")]
        private IWebElement username;

        [FindsBy(How = How.XPath, Using = "//div[@class='form-group'][5]/label/span/input")]
        private IWebElement checkBox;

        [FindsBy(How = How.Name, Using = "password")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "signInBtn")]
        private IWebElement signInBtn;

        public ProductsPage ValidLogin(string user, string pass)
        {
            username.SendKeys(user);
            password.SendKeys(pass);
            checkBox.Click();
            signInBtn.Click();
            return new ProductsPage(driver);
        }

        public IWebElement GetUserName() => username;
        public IWebElement GetUPasswortd() => password;
        public IWebElement GetCheckBox() => checkBox;
        public IWebElement GetSignInBtn() => signInBtn;

    }
}
