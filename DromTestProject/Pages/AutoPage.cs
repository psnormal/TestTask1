using Allure.Net.Commons;
using NUnit.Allure.Core;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DromTestProject.Pages
{
    public class AutoPage
    {
        private IWebDriver driver;
        public AutoPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        //марка
        private By brand = By.XPath("//div[@data-ftid='sales__filter_fid']//input");
        //модель
        private By model = By.XPath("//div[@data-ftid='sales__filter_mid']//input");
        //год выпуска от
        private By yearFrom = By.XPath("//div[@data-ftid='sales__filter_year-from']//button");
        //тип топлива
        private By fuel = By.XPath("//div[@data-ftid='sales__filter_fuel-type']//button");
        //непроданные
        private By unsold = By.XPath("//label[contains(text(), 'Непроданные')]");
        //расширенный поиск
        private By advancedSearch = By.XPath("//button[@data-ftid='sales__filter_advanced-button']");
        //пробег от
        private By mileageFrom = By.XPath("//input[@data-ftid='sales__filter_mileage-from']");
        //кнопка Показать
        private By showButton = By.XPath("//button[@data-ftid='sales__filter_submit-button']");

        //кнопка Добавить в избранное
        private By addToFavorite = By.XPath("//button[@data-ftid='component_favorite_button_add']");

        //кнопка Другой город
        private By anotherCity = By.XPath("//a[@data-ga-stats-name='geoOverCity']");

        //кнопка Показать все
        private By showAllButton = By.XPath("//div[contains(text(), 'Показать все')]");

        public AutoPage OpenAutoPage()
        {
            driver.Navigate().GoToUrl("http://auto.drom.ru/");
            return this;
        }

        public AutoPage ChooseBrand(string AutoBrand)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(brand));
                driver.FindElement(brand).Click();
                driver.FindElement(brand).SendKeys(AutoBrand);
                driver.FindElement(By.XPath("//div[@role='option']")).Click();
            }, "Выбрать марку автомобиля");
            return this;
        }

        public AutoPage ChooseModel(string AutoModel)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(model));
                driver.FindElement(model).Click();
                driver.FindElement(model).SendKeys(AutoModel);
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'" + AutoModel + "')]")));
                driver.FindElement(By.XPath("//div[contains(text(),'" + AutoModel + "')]")).Click();
            }, "Выбрать модель автомобиля");
            return this;
        }

        public AutoPage ChooseYearFrom(string YearFrom)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(yearFrom));
                driver.FindElement(yearFrom).Click();
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'" + YearFrom + "')]")));
                driver.FindElement(By.XPath("//div[contains(text(),'" + YearFrom + "')]")).Click();
            }, "Указать минимальный год выпуска");
            return this;
        }

        public AutoPage ChooseFuel(string FuelType)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(fuel));
                driver.FindElement(fuel).Click();
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'" + FuelType + "')]")));
                driver.FindElement(By.XPath("//div[contains(text(),'" + FuelType + "')]")).Click();
            }, "Выбрать тип топлива");
            return this;
        }

        public AutoPage ChooseUnsold()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementIsVisible(unsold));
                driver.FindElement(unsold).Click();
            }, "Выбрать непроданные");
            return this;
        }

        public AutoPage ChooseAdvancedSearch()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(advancedSearch));
                driver.FindElement(advancedSearch).Click();
            }, "Открыть расширенные настройки");
            return this;
        }

        public AutoPage ChooseMileageFrom(string Mileage)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(mileageFrom)).SendKeys(Mileage);
            }, "Указать минимальный пробег");
            return this;
        }

        public AutoPage PressOnShowButton()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(showButton));
                driver.FindElement(showButton).Click();
            }, "Нажать кнопку Показать");
            return this;
        }

        public AutoPage AddToFavorite()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(addToFavorite));
                driver.FindElement(addToFavorite).Click();
            }, "Нажать кнопку Добавить в избранное");
            return this;
        }

        public AutoPage ClickOnAnotherCityButton()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(anotherCity));
                driver.FindElement(anotherCity).Click();
            }, "Нажать кнопку Другой город");
            return this;
        }

        public AutoPage ChooseRegion(string Region)
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(), '" + Region + "')]")));
                driver.FindElement(By.XPath("//div[contains(text(), '" + Region + "')]")).Click();
                driver.FindElement(By.XPath("//div[contains(text(), 'Все города региона')]")).Click();
            }, "Выбрать регион");
            return this;
        }

        public AutoPage ClickOnShowAllButton()
        {
            AllureLifecycle.Instance.WrapInStep(() =>
            {
                new WebDriverWait(driver, new TimeSpan(0, 0, 15)).
                Until(ExpectedConditions.ElementToBeClickable(showAllButton));
                driver.FindElement(showAllButton).Click();
            }, "Нажать кнопку Показать все");
            return this;
        }
    }
}
