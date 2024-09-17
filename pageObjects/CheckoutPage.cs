using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace C_SeleniumSelfFramework.pageObjects
{
    public class CheckoutPage
    {
        private readonly IWebDriver driver;

        public CheckoutPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "h4 a")]
        private IList<IWebElement> checkoutCards;

        [FindsBy(How = How.CssSelector, Using = ".btn-success")]
        private IWebElement checkoutBtn;


        public IList<IWebElement> GetCheckoutCards() => checkoutCards;
        public ConfirmationPage Checkout()
        {
            checkoutBtn.Click();
            return new ConfirmationPage(driver);
        }
    }
}
