using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace C_SeleniumSelfFramework.pageObjects
{
    public class ConfirmationPage
    {
        private readonly IWebDriver driver;

        public ConfirmationPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "country")]
        private IWebElement inputCountry;

        [FindsBy(How = How.LinkText, Using = "India")]
        private IWebElement selectCountry;

        [FindsBy(How = How.CssSelector, Using = "label[for*='checkbox2']")]
        private IWebElement checkboxBtn;

        [FindsBy(How = How.XPath, Using = "//input[@value='Purchase']")]
        private IWebElement purchaseBtn;

        [FindsBy(How = How.CssSelector, Using = ".alert-success")]
        private IWebElement confirmMsg;

        public IWebElement ConfirmationMessage() => confirmMsg;

        public void ConfirmPurchase(string input)
        {
            inputCountry.SendKeys(input);
            WaitForPageDisplay();
            selectCountry.Click();
            checkboxBtn.Click();
            purchaseBtn.Click();
        }

        //var confirmationText = driver.FindElement(By.CssSelector(".alert-success")).Text;

        public void WaitForPageDisplay()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
        }

    }
}
