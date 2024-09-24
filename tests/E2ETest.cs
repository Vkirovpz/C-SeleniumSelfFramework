using C_SeleniumSelfFramework.pageObjects;
using C_SeleniumSelfFramework.utilities;

namespace C_SeleniumSelfFramework.tests
{
    //run all test methods in one class parallel
    //[Parallelizable(ParallelScope.Children)]
    public class End2EndTest : Base
    {
        [Test, TestCaseSource("AddTestDataConfig")]
        //run all data sets of test method in parallel
        [Parallelizable(ParallelScope.All)]
        public void EndToEndFlow(string username, string password, String[] expectedProducts)
        {
            string[] actualProducts = new string[2];

            LoginPage loginPage = new LoginPage(GetDriver());
            ProductsPage productsPage = loginPage.ValidLogin(username, password);
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
            Assert.That(confirmationPage.ConfirmationMessage().Text.Contains("Success"));
        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {
            yield return new TestCaseData(GetDataParser().ExtractData("username"), GetDataParser().ExtractData("password"), GetDataParser().ExtractDataArray("products"));
            yield return new TestCaseData(GetDataParser().ExtractData("username_wrong"), GetDataParser().ExtractData("password_wrong"), GetDataParser().ExtractDataArray("products"));
        }
    }
}
