using GreenLightHealth.Client.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using Xunit;

namespace GreenLightHealth.AutomatedUITests
{
    public class HomeAutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        private string site = "https://localhost:44386/";
        public HomeAutomatedUITests()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl(site);
        }

        public void Dispose()
        {
            _driver.Quit();
            _driver.Dispose();
        }

        [Fact]
        public void HomeViewExists()
        {
            Assert.Equal("Green Light Healthy - Health Declaration", _driver.Title);
            Assert.Contains("Green Light? Healthy!", _driver.PageSource);
        }

        [Fact]
        public void HomeViewFirstContainerContentIsVisibleWithStoplight()
        {
            // Act:
            IWebElement containerElement = _driver.FindElement(By.Id("container1"));
            IReadOnlyCollection<IWebElement> childElements = containerElement.FindElements(By.XPath(".//*"));

            // Assert:
            Assert.NotNull(containerElement);
            Assert.True(containerElement.Displayed);
            Assert.True(containerElement.Enabled);
            Assert.NotNull(childElements);
            bool stoplightFound = false;
            foreach(IWebElement element in childElements)
            {
                if(element.TagName.Contains("span"))
                {
                    Assert.True(element.Displayed);
                    Assert.True(element.Enabled);
                    string classes = element.GetAttribute("class");
                    Assert.Contains("stoplight", classes);
                    stoplightFound = true;
                }
            }
            Assert.True(stoplightFound);
        }

        [Fact]
        public void HomeViewSecondContainerContentIsVisibleWithHealthDeclaration()
        {
            // Arrange;
            HealthDeclarationViewModel healthDeclarationViewModel = new HealthDeclarationViewModel();

            // Act:
            IWebElement containerElement = _driver.FindElement(By.Id("container2"));
            IReadOnlyCollection<IWebElement> childElements = containerElement.FindElements(By.XPath(".//*"));

            // Assert:
            Assert.NotNull(containerElement);
            Assert.True(containerElement.Displayed);
            Assert.True(containerElement.Enabled);
            Assert.NotNull(childElements);
            bool healthDeclarationFound = false;
            foreach (IWebElement element in childElements)
            {
                if (element.TagName.Contains("p"))
                {
                    if(element.Text.Contains(healthDeclarationViewModel.HealthDeclaration)) {
                        healthDeclarationFound = true;
                        Assert.True(element.Displayed);
                        Assert.True(element.Enabled);
                    }
                }
            }
            Assert.True(healthDeclarationFound);
        }

        [Fact]
        public void HomeViewThirdContainerExists()
        {
            // Act:
            IWebElement containerElement = _driver.FindElement(By.Id("container3"));

            // Assert:
            Assert.NotNull(containerElement);
            Assert.True(containerElement.Displayed);
            Assert.True(containerElement.Enabled);
        }
    }
}
