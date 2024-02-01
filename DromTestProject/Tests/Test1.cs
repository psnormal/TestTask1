using DromTestProject.Pages;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace DromTestProject.Tests
{
    [TestFixture]
    [Parallelizable]
    [AllureNUnit]
    [AllureDisplayIgnored]
    public class Test1
    {
        private IWebDriver _driver;
        AutoPage _autoPage;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            _autoPage = new AutoPage(_driver);
        }

        [SetUp]
        public void SetUp()
        {
            _autoPage.OpenAutoPage()
                     .ChooseBrand("Toyota")
                     .ChooseModel("Harrier")
                     .ChooseYearFrom("2007")
                     .ChooseFuel("Гибрид")
                     .ChooseUnsold()
                     .ChooseAdvancedSearch()
                     .ChooseMileageFrom("1")
                     .PressOnShowButton();
        }

        [Test, Order(1), TestCase(TestName = "Первая страница с объявлениями, нет проданных авто")]
        public void Test11()
        {
            bool allUnsold = true;
            if (_driver.FindElements(By.XPath("//div[contains(text(), 'снят с продажи')]")).Count() > 0)
                allUnsold = false;
            Assert.That(allUnsold, Is.True);
        }

        [Test, Order(2), TestCase(TestName = "Вторая страница с объявлениями, нет проданных авто")]
        public void Test12()
        {
            _driver.FindElement(By.XPath("//a[text()='2']")).Click();
            bool allUnsold = true;
            if (_driver.FindElements(By.XPath("//div[contains(text(), 'снят с продажи')]")).Count() > 0)
                allUnsold = false;
            Assert.That(allUnsold, Is.True);
        }

        [Test, Order(3), TestCase(TestName = "Первая страница с объявлениями, год выпуска от 2007")]
        public void Test13()
        {
            bool yearIsCorrect = true;
            var cars = _driver.FindElements(By.XPath("//span[@data-ftid='bull_title']")).ToList();
            foreach (var car in cars)
            {
                var year = car.Text.Remove(0, 15);
                int yearNumber = Int32.Parse(year);
                if (yearNumber < 2007)
                    yearIsCorrect = false;
            }
            Assert.That(yearIsCorrect, Is.True);
        }

        [Test, Order(4), TestCase(TestName = "Вторая страница с объявлениями, год выпуска от 2007")]
        public void Test14()
        {
            _driver.FindElement(By.XPath("//a[text()='2']")).Click();
            bool yearIsCorrect = true;
            var cars = _driver.FindElements(By.XPath("//span[@data-ftid='bull_title']")).ToList();
            foreach (var car in cars)
            {
                var year = car.Text.Remove(0, 15);
                int yearNumber = Int32.Parse(year);
                if (yearNumber < 2007)
                    yearIsCorrect = false;
            }
            Assert.That(yearIsCorrect, Is.True);
        }

        [Test, Order(5), TestCase(TestName = "Первая страница с объявлениями, все авто с пробегом")]
        public void Test15()
        {
            bool mileageIsCorrect = true;
            if (_driver.FindElements(By.XPath("//span[@data-ftid='bull_title']")).Count() != _driver.FindElements(By.XPath("//span[contains(text(), 'км')]")).Count())
                mileageIsCorrect = false;
            Assert.That(mileageIsCorrect, Is.True);
        }

        [Test, Order(6), TestCase(TestName = "Вторая страница с объявлениями, все авто с пробегом")]
        public void Test16()
        {
            _driver.FindElement(By.XPath("//a[text()='2']")).Click();
            bool mileageIsCorrect = true;
            if (_driver.FindElements(By.XPath("//span[@data-ftid='bull_title']")).Count() != _driver.FindElements(By.XPath("//span[contains(text(), 'км')]")).Count())
                mileageIsCorrect = false;
            Assert.That(mileageIsCorrect, Is.True);
        }
    }
}
