using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using Xunit;

namespace GreenLightHealth.AutomatedUITests
{
    public class HomeAutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        public HomeAutomatedUITests()
        {
            _driver = new ChromeDriver();
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void HealthDeclaration()
        {
            _driver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.Equal("Green Light Healthy - Health Declaration", _driver.Title);
            Assert.Contains("Green Light? Healthy!", _driver.PageSource);
        }
    }
}
