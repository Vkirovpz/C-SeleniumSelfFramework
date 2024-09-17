using C_SeleniumSelfFramework.pageObjects;
using C_SeleniumSelfFramework.utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace C_SeleniumSelfFramework.tests
{
    public class End2EndTest : Base
    {

        [Test]
        public void EndToEndFlow()
        {
            string[] expectedProducts = { "iphone X", "Blackberry" };
            string[] actualProducts = new string[2];

            LoginPage loginPage = new LoginPage(GetDriver());
            ProductsPage productsPage = loginPage.ValidLogin("rahulshettyacademy", "learning");
            productsPage.WaitForPageDisplay();

            foreach (var product in productsPage.GetCards())
            {
                if (expectedProducts.Contains(product.FindElement(productsPage.GetCardTitle()).Text))
                    product.FindElement(productsPage.AddToCartBtn()).Click();
            }

            CheckoutPage checkoutPage = productsPage.Checkout();

            var checkoutCards = checkoutPage.GetCheckoutCards();

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }

            Assert.That(expectedProducts, Is.EqualTo(actualProducts));

            ConfirmationPage confirmationPage = checkoutPage.Checkout();

            confirmationPage.ConfirmPurchase("ind");
            StringAssert.Contains("Success", confirmationPage.ConfirmationMessage().Text);
        }
    }
}
