using GreenLightHealth.Client.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace GreenLightHealth.AutomatedUITests
{
    public class HomeAutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        private string site = "https://localhost:44386/";
        private readonly HomeViewModel homeViewModel;

        public HomeAutomatedUITests()
        {
            homeViewModel = new HomeViewModel();
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
            Assert.Contains(containerElement.GetAttribute("class"), "container-fluid bg-1 text-center");
            Assert.NotNull(childElements);
            bool stoplightFound = false;
            foreach(IWebElement element in childElements)
            {
                if(element.TagName.Contains("span"))
                {
                    Assert.True(element.Displayed);
                    Assert.True(element.Enabled);
                    string spanClasses = element.GetAttribute("class");
                    Assert.Contains("stoplight", spanClasses);
                    stoplightFound = true;
                }
            }
            Assert.True(stoplightFound);
        }

        [Fact]
        public void HomeViewSecondContainerContentIsVisibleWithHealthDeclaration()
        {
            // Act:
            IWebElement containerElement = _driver.FindElement(By.Id("container2"));
            IReadOnlyCollection<IWebElement> childElements = containerElement.FindElements(By.XPath(".//*"));

            // Assert:
            Assert.NotNull(containerElement);
            Assert.True(containerElement.Displayed);
            Assert.True(containerElement.Enabled);
            Assert.Contains(containerElement.GetAttribute("class"), "container-fluid bg-2 text-center");
            Assert.NotNull(childElements);
            bool healthDeclarationHeaderFound = false;
            bool healthDeclarationParagraphFound = false;
            bool acceptButtonFound = false;
            bool declineButtonFound = false;
            foreach (IWebElement element in childElements)
            {
                if (element.TagName.Contains("h3"))
                {
                    if (element.Text.Contains(homeViewModel.HealthDeclarationHeader))
                    {
                        healthDeclarationHeaderFound = true;
                        Assert.True(element.Displayed);
                        Assert.True(element.Enabled);
                    }
                }

                if (element.TagName.Contains("p"))
                {
                    if(element.Text.Contains(homeViewModel.HealthDeclarationParagraph)) {
                        healthDeclarationParagraphFound = true;
                        Assert.True(element.Displayed);
                        Assert.True(element.Enabled);
                    }
                }

                if (element.TagName.Contains("button"))
                {
                    if (element.Text.Contains(homeViewModel.AcceptText))
                    {
                        acceptButtonFound = true;
                        Assert.True(element.Displayed);
                        Assert.True(element.Enabled);
                    }

                    if (element.Text.Contains(homeViewModel.DeclineText))
                    {
                        declineButtonFound = true;
                        Assert.True(element.Displayed);
                        Assert.True(element.Enabled);
                    }
                }
            }
            Assert.True(healthDeclarationHeaderFound);
            Assert.True(healthDeclarationParagraphFound);
            Assert.True(acceptButtonFound);
            Assert.True(declineButtonFound);
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
            Assert.Contains(containerElement.GetAttribute("class"), "container-fluid bg-3 text-center");
        }

        [Fact]
        public void HomeViewStoplightBecomesGreenAfterAcceptIsClicked()
        {
            // Arrange:
            IWebElement stoplightElement = _driver.FindElement(By.Id(homeViewModel.StoplightId));
            IWebElement button = _driver.FindElement(By.Id(homeViewModel.AcceptId));

            // Act:
            button.Click();
            Thread.Sleep(1000);

            // Assert:
            Assert.NotNull(stoplightElement);
            Assert.NotNull(button);
            Assert.Contains("green", stoplightElement.GetAttribute("class"));
        }

        [Fact]
        public void HomeViewStoplightBecomesRedAfterRejectIsClicked()
        {
            // Arrange:
            IWebElement stoplightElement = _driver.FindElement(By.Id(homeViewModel.StoplightId));
            IWebElement button = _driver.FindElement(By.Id(homeViewModel.DeclineId));

            // Act:
            button.Click();

            // Assert:
            Assert.NotNull(stoplightElement);
            Assert.NotNull(button);
            Assert.Contains("red", stoplightElement.GetAttribute("class"));
        }

        [Fact]
        public void HomeViewContainsAcceptElement()
        {
            // Act:
            IWebElement acceptButton = _driver.FindElement(By.Id(homeViewModel.AcceptId));

            // Assert:
            Assert.True(acceptButton.Displayed);
        }

        [Fact]
        public void HomeViewContainsDeclineElement()
        {
            // Act:
            IWebElement acceptButton = _driver.FindElement(By.Id(homeViewModel.DeclineId));

            // Assert:
            Assert.True(acceptButton.Displayed);
        }
    }
}
