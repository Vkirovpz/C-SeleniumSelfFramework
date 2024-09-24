using OpenQA.Selenium;
using C_SeleniumSelfFramework.utilities;

namespace C_SeleniumSelfFramework.tests
{
    public class WindowHandlers : Base
    {

        [Test]
        public void WindowHandle()
        {
            driver.Value.FindElement(By.CssSelector(".blinkingText")).Click();
            Assert.That(driver.Value.WindowHandles.Count, Is.EqualTo(3));

            var childWindowName = driver.Value.WindowHandles[2];
            driver.Value.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector(".red")).Text);
        }

        [Test]
        public void ExtractEmailFromChildWindow()
        {
            var expectedEmail = "mentor@rahulshettyacademy.com";
            var mainWindow = driver.Value.CurrentWindowHandle;

            driver.Value.FindElement(By.CssSelector(".blinkingText")).Click();
            Assert.That(driver.Value.WindowHandles.Count, Is.EqualTo(3));

            var childWindowName = driver.Value.WindowHandles[2];
            driver.Value.SwitchTo().Window(childWindowName);
            TestContext.Progress.WriteLine(driver.Value.FindElement(By.CssSelector(".red")).Text);
            var extractedEmail = driver.Value.FindElement(By.CssSelector(".red a")).Text;

            Assert.That(extractedEmail, Is.EqualTo(expectedEmail));

            driver.Value.SwitchTo().Window(mainWindow);
            driver.Value.FindElement(By.Id("username")).SendKeys(extractedEmail);
        }
    }
}
