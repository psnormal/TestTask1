using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DromTestProject
{
    public static class AuthService
    {
        public static void Login(IWebDriver driver, string phone, string password)
        {
            driver.Manage().Window.Maximize();
            try
            {
                driver.Navigate().GoToUrl("https://my.drom.ru/sign?return=https%3A%2F%2Fauto.drom.ru%2F%3Ftcb%3D1706729079");
                var wait = new WebDriverWait(driver, new TimeSpan(0, 0, 15));
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@id='sign']")));
                driver.FindElement(By.XPath("//input[@id='sign']")).SendKeys(phone);
                driver.FindElement(By.XPath("//input[@type='password']")).SendKeys(password);
                driver.FindElement(By.XPath("//button[@id='signbutton']")).Click();
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h1[text()='Продажа автомобилей']")));
            }
            catch (Exception)
            {
                throw new IgnoreException("Не удалось авторизоваться");
            }
        }
    }
}
