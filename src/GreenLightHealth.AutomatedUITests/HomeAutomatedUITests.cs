using GreenLightHealth.Client.Constants;
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
        private const string SITE = "https://localhost:44386/";
        private readonly HomeViewModel homeViewModel;
        private readonly IJavaScriptExecutor javaScriptExecutor;
        private const string USER_FULL_NAME = "Test User";
        private const string USER_EMAIL = "test@user.com";
        private const string FIRST_NAME_LAST_NAME_KEY = "firstNameLastName";
        private const string REGISTRATION_FORM_ID = "health-declaration-form";
        private const int WAIT_TIME_IN_MILLISECONDS = 100;
        private const int MAX_WAIT_TIME_IN_MILLISECONDS = 2000;

        public HomeAutomatedUITests()
        {
            homeViewModel = new HomeViewModel();
            _driver = new ChromeDriver();
            javaScriptExecutor = (IJavaScriptExecutor) _driver;
            _driver.Navigate().GoToUrl(SITE);
            javaScriptExecutor.ExecuteScript("localStorage.setItem('" + FIRST_NAME_LAST_NAME_KEY + "','');");
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
        public void HomeViewPresentsLoginRegistrationFormToUnidentifiedUser()
        {
            // Arrange:
            IWebElement element;

            // Act:
            element = FindElementByIdWithWaitTimer(ViewConstants.RegistrationForm);

            // Assert:
            Assert.NotNull(element);
            Assert.True(element.Displayed);
            Assert.True(element.Enabled);
        }

        [Fact]
        public void HomeViewDoesNotPresentsLoginRegistrationFormToIdentifiedUser()
        {
            // Arrange: (see test constructor)
            SubmitRegistrationForm();
            _driver.Navigate().GoToUrl(SITE);

            // Act:
            var element = FindElementByIdWithWaitTimer(ViewConstants.RegistrationForm);

            // Assert:
            Assert.NotNull(element);
            Assert.False(element.Displayed);
            Assert.True(element.Enabled);
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

                    IReadOnlyCollection<IWebElement> stoplightChildElements = element.FindElements(By.XPath(".//*"));
                    foreach (IWebElement stoplightChildElement in stoplightChildElements)
                    {
                        Assert.Contains("img", stoplightChildElement.TagName);
                        Assert.Contains("qr-code.png", stoplightChildElement.GetAttribute("src"));
                    }
                }
            }
            Assert.True(stoplightFound);
        }

        [Fact]
        public void HomeViewPresentsHealthDeclarationToNewUser()
        {
            // Arrange:
            SubmitRegistrationForm();

            // Act:
            var element = FindElementByIdWithWaitTimer("health-declaration-form");

            // Assert:
            Assert.NotNull(element);
            Assert.True(element.Displayed);
            Assert.True(element.Enabled);
        }

        [Fact]
        public void HomeViewPresentsHealthDeclarationToIdentifiedUser()
        {
            // Arrange:
            NavigateToPageAsLoggedInUser();

            // Act:
            var element = FindElementByIdWithWaitTimer(REGISTRATION_FORM_ID);

            // Assert:
            Assert.NotNull(element);
            Assert.True(element.Displayed);
            Assert.True(element.Enabled);
        }

        [Fact]
        public void HomeViewHealthDeclarationFormFormatIsCorrect()
        {
            // Act:
            IWebElement containerElement = _driver.FindElement(By.Id(REGISTRATION_FORM_ID));
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
                    if (element.Text.Equals(homeViewModel.HealthDeclarationHeader))
                    {
                        healthDeclarationHeaderFound = true;
                        Assert.True(element.Displayed);
                        Assert.True(element.Enabled);
                    }
                }

                if (element.TagName.Contains("p"))
                {
                    if(element.Text.Equals(homeViewModel.HealthDeclarationParagraph)) {
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

                    if (element.Text.Equals(homeViewModel.DeclineText))
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
            SubmitRegistrationForm();
            IWebElement stoplightElement = _driver.FindElement(By.Id(homeViewModel.StoplightId));
            IWebElement button = _driver.FindElement(By.Id(homeViewModel.AcceptId));

            // Act:
            ClickWithWaitTimer(button);

            // Assert:
            Assert.NotNull(stoplightElement);
            Assert.NotNull(button);
            Assert.Contains("green", stoplightElement.GetAttribute("class"));
        }

        [Fact]
        public void HomeViewStoplightBecomesRedAfterRejectIsClicked()
        {
            // Arrange:
            SubmitRegistrationForm();
            IWebElement stoplightElement = FindElementByIdWithWaitTimer(homeViewModel.StoplightId);
            IWebElement button = FindElementByIdWithWaitTimer(homeViewModel.DeclineId);

            // Act:
            ClickWithWaitTimer(button);

            // Assert:
            Assert.NotNull(stoplightElement);
            Assert.NotNull(button);
            Assert.Contains("red", stoplightElement.GetAttribute("class"));
        }

        [Fact]
        public void HomeViewContainsAcceptElement()
        {
            // Arrange:
            SubmitRegistrationForm();

            // Act:
            IWebElement acceptButton = _driver.FindElement(By.Id(homeViewModel.AcceptId));

            // Assert:
            Assert.True(acceptButton.Displayed);
        }

        [Fact]
        public void HomeViewContainsDeclineElement()
        {
            // Arrange:
            SubmitRegistrationForm();

            // Act:
            IWebElement acceptButton = _driver.FindElement(By.Id(homeViewModel.DeclineId));

            // Assert:
            Assert.True(acceptButton.Displayed);
        }

        private void SubmitRegistrationForm()
        {
            IWebElement nameInputElement = FindElementByIdWithWaitTimer(ViewConstants.NameId);
            IWebElement emailInputElement = FindElementByIdWithWaitTimer(ViewConstants.EmailId);
            IWebElement submitButtonElement = FindElementByIdWithWaitTimer(ViewConstants.BtnAcceptId);
            nameInputElement.SendKeys(USER_FULL_NAME);
            emailInputElement.SendKeys(USER_EMAIL);
            ClickWithWaitTimer(submitButtonElement);
        }

        private IWebElement FindElementByIdWithWaitTimer(string elementId)
        {
            int sleepTimerDeltaBackofInMillieseconds = WAIT_TIME_IN_MILLISECONDS;
            int totalSleepTime = 0;
            IWebElement element = null;
            while (element == null && totalSleepTime < MAX_WAIT_TIME_IN_MILLISECONDS)
            {
                Thread.Sleep(sleepTimerDeltaBackofInMillieseconds);
                element = _driver.FindElement(By.Id(elementId));
                totalSleepTime += sleepTimerDeltaBackofInMillieseconds;
                sleepTimerDeltaBackofInMillieseconds += sleepTimerDeltaBackofInMillieseconds;
            }
            return element;
        }

        private void NavigateToPageAsLoggedInUser()
        {
            javaScriptExecutor.ExecuteScript("localStorage.setItem('" + FIRST_NAME_LAST_NAME_KEY + "','" + USER_FULL_NAME + "');");
            _driver.Navigate().GoToUrl(SITE);
            Thread.Sleep(5 * WAIT_TIME_IN_MILLISECONDS);
        }

        private void ClickWithWaitTimer(IWebElement element)
        {
            element.Click();
            Thread.Sleep(5 * WAIT_TIME_IN_MILLISECONDS);
        }
    }
}
