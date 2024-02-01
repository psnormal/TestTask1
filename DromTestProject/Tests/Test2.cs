using DromTestProject.Pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace DromTestProject.Tests
{
    [TestFixture]
    [Parallelizable]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class Test2
    {
        private IWebDriver _driver;
        AutoPage _autoPage;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _autoPage = new AutoPage(_driver);
            AuthService.Login(_driver, "79617363533", "testpass123");
        }

        [Test, TestCase(TestName = "Добавить объявление в избранное и проверить это")]
        public void Test21()
        {
            bool isAdded = false;
            var car = _driver.FindElement(By.XPath("//span[@data-ftid='bull_title']")).Text;
            _autoPage.AddToFavorite();
            _driver.Navigate().GoToUrl("https://my.drom.ru/personal/bookmark");
            if (_driver.FindElement(By.XPath("//a[contains(text(), '" + car + "')]")).Displayed)
                isAdded = true;
            Assert.That(isAdded, Is.True);
        }
    }
}
