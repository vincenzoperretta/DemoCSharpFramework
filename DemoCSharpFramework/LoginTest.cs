using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace DemoCSharpFramework
{
    /// <summary>
    /// Summary description for LoginTest
    /// </summary>
    [TestFixture]
    public class LoginTest
    {
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            driver = new ChromeDriver("C:\\Users\\Vincenzo.Perretta\\source\\repos\\DemoCSharpFramework\\DemoCSharpFramework\\bin\\Debug\\");
            driver.Url = "https://www.saucedemo.com/";
        }

        [Test]
        public void LoginPageTest()
        {
            IWebElement email = driver.FindElement(By.Id("user-name"));
            email.SendKeys("standard_user");
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");
            IWebElement signIn = driver.FindElement(By.Id("login-button"));
            signIn.Click();
            IWebElement products = driver.FindElement(By.XPath("//*[@id='header_container']/div[2]/span"));
            String productText = products.Text;
            Assert.AreEqual("PRODUCTS", productText);
        }

        [OneTimeTearDown]
        public void Teardown()
        {
            driver.Close();
        }

    }
}
