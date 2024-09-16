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

            driver.FindElement(By.Id("username")).SendKeys("rahulshettyacademy");
            driver.FindElement(By.Name("password")).SendKeys("learning");
            driver.FindElement(By.XPath("//div[@class='form-group'][5]/label/span/input")).Click();
            driver.FindElement(By.Id("signInBtn")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.PartialLinkText("Checkout")));

            var products = driver.FindElements(By.TagName("app-card"));
            foreach (var product in products)
            {
                var productName = product.FindElement(By.CssSelector(".card-title a")).Text;

                if (expectedProducts.Contains(productName))
                {
                    product.FindElement(By.CssSelector(".card-footer button")).Click();
                }
            }

            driver.FindElement(By.PartialLinkText("Checkout")).Click();
            var checkoutCards = driver.FindElements(By.CssSelector("h4 a"));

            for (int i = 0; i < checkoutCards.Count; i++)
            {
                actualProducts[i] = checkoutCards[i].Text;
            }

            Assert.That(expectedProducts, Is.EqualTo(actualProducts));

            driver.FindElement(By.XPath("//button[@class='btn btn-success']")).Click();

            driver.FindElement(By.Id("country")).SendKeys("ind");
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.LinkText("India")));
            driver.FindElement(By.LinkText("India")).Click();

            driver.FindElement(By.CssSelector("label[for*='checkbox2']")).Click();
            driver.FindElement(By.XPath("//input[@value='Purchase']")).Click();

            var confirmationText = driver.FindElement(By.CssSelector(".alert-success")).Text;
            StringAssert.Contains("Success", confirmationText);
        }
    }
}
