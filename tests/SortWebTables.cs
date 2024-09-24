using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using C_SeleniumSelfFramework.utilities;

namespace C_SeleniumSelfFramework.tests
{
    public class SortWebTables : Base
    {
        [Test]
        public void SortTable()
        {
            var initialList = new List<string>();


            SelectElement dropdown = new SelectElement(driver.Value.FindElement(By.Id("page-menu")));
            dropdown.SelectByValue("20");

            //Get all products into initial list
            var productsA = driver.Value.FindElements(By.XPath("//tr/td[1]"));
            foreach (var product in productsA)
            {
                initialList.Add(product.Text);
            }

            //Sort the initial list
            initialList.Sort();

            //Click the Column to sort in web
            driver.Value.FindElement(By.CssSelector("th[aria-label *= 'fruit name']")).Click();

            //Get all products into sortedListWeb
            var sortedListWeb = new List<string>();
            var productsB = driver.Value.FindElements(By.XPath("//tr/td[1]"));
            foreach (var product in productsB)
            {
                sortedListWeb.Add(product.Text);
            }

            //Assert sorted and web sorted lists are equals
            //Assert.AreEqual(initialList, sortedListWeb);
            Assert.That(sortedListWeb, Is.EqualTo(initialList));
        }
    }
}
