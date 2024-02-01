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
    public class Test3
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
            _autoPage.OpenAutoPage();
        }

        [Test, TestCase(TestName = "Отсортировать и вывести 20 самых популярных марок авто в Приморском крае")]
        public void Test31()
        {
            _autoPage.ClickOnAnotherCityButton()
                     .ChooseRegion("Приморский край")
                     .ClickOnShowAllButton();

            var brands = _driver.FindElements(By.XPath("//div[@class='css-1q61nn e4ojbx42']")).ToList();
            var keys = new List<int>();
            var items = new List<string>();
            foreach (var brand in brands)
            {
                if (brand.FindElements(By.XPath(@"./*//span[@data-ftid='component_cars-list-item_counter']")).Count != 0)
                {
                    keys.Add(Int32.Parse(brand.FindElement(By.XPath(@"./*//span[@data-ftid='component_cars-list-item_counter']")).Text));
                    items.Add(brand.FindElement(By.XPath(@"./*//span[@data-ftid='component_cars-list-item_name']")).Text);
                }
            }
            var keysArray = keys.ToArray();
            var itemsArray = items.ToArray();
            Array.Sort(keysArray, itemsArray);

            Console.WriteLine("| Фирма | Количество объявлений |");
            for (int i = keysArray.Length - 1; i > keysArray.Length - 21; i--)
            {
                Console.WriteLine("| " + itemsArray[i] + " | " + keysArray[i].ToString() + " |");
            }

            Assert.That(true, Is.True);
        }
    }
}
