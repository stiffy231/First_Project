using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class MedCreationTests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://1pgb.ru";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void MedCreationTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            driver.FindElement(By.CssSelector("a > span.btn-in")).Click();
            //driver.FindElement(By.Name("Codeword")).Clear();
            //driver.FindElement(By.Name("Codeword")).SendKeys("rested1");
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.CssSelector("div.scrollPopUp")).Click();
            driver.FindElement(By.LinkText("Больничный и пособие")).Click();
            System.Threading.Thread.Sleep(500);
            driver.FindElement(By.XPath("(//a[contains(text(),'Алексеева Марина Владимировна')])[2]")).Click();
            System.Threading.Thread.Sleep(15000);
            driver.FindElement(By.XPath("//div[@id='date_container_']/span/span/span/span")).Click();
            driver.FindElement(By.XPath("//div[@id='date_container_']/span/span/span[2]/div/div[3]/span[8]")).Click();
            
            driver.FindElement(By.Id("komandlabel1")).Click();
            driver.FindElement(By.Id("komandlabel1")).Clear();
            driver.FindElement(By.Id("komandlabel1")).SendKeys("111 111 111 111");
            // ERROR: Caught exception [Error: Dom locators are not implemented yet!]
            driver.FindElement(By.XPath("//body/div[9]")).Click();
            //driver.FindElement(By.CssSelector("span.company-menu-dropdown__caller.ng-binding")).Click();
           // driver.FindElement(By.LinkText("Выйти")).Click();
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
