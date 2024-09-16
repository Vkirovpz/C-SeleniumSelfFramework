using OpenQA.Selenium;
using C_SeleniumSelfFramework.utilities;

namespace C_SeleniumSelfFramework.tests
{
    public class WindowHandlers : Base
    {

        [Test]
        public void WindowHandle()
        {
            driver.FindElement(By.CssSelector(".blinkingText")).Click();
            Assert.That(driver.WindowHandles.Count, Is.EqualTo(3));

            var childWindowName = driver.WindowHandles[2];
            driver.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);
        }

        [Test]
        public void ExtractEmailFromChildWindow()
        {
            var expectedEmail = "mentor@rahulshettyacademy.com";
            var mainWindow = driver.CurrentWindowHandle;

            driver.FindElement(By.CssSelector(".blinkingText")).Click();
            Assert.That(driver.WindowHandles.Count, Is.EqualTo(3));

            var childWindowName = driver.WindowHandles[2];
            driver.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.FindElement(By.CssSelector(".red")).Text);
            var extractedEmail = driver.FindElement(By.CssSelector(".red a")).Text;

            Assert.That(extractedEmail, Is.EqualTo(expectedEmail));

            driver.SwitchTo().Window(mainWindow);
            driver.FindElement(By.Id("username")).SendKeys(extractedEmail);
        }
    }
}
