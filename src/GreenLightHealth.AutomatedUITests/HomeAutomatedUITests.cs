using GreenLightHealth.Client.Constants;
using GreenLightHealth.Client.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;
using Xunit;

namespace GreenLightHealth.AutomatedUITests
{
    public class HomeAutomatedUITests : IDisposable
    {
        private readonly IWebDriver _driver;
        private readonly Actions actions;
        private const string SITE = "https://localhost:44386/";
        private readonly HomeViewModel homeViewModel;
        private readonly IJavaScriptExecutor javaScriptExecutor;
        private const string USER_FULL_NAME = "Test User";
        private const string USER_EMAIL = "test@user.com";
        private const string FIRST_NAME_LAST_NAME_KEY = "firstNameLastName";
        private const int WAIT_TIME_IN_MILLISECONDS = 100;
        private const int MAX_WAIT_TIME_IN_MILLISECONDS = 2000;
        private const int DEMO_USER_DELAY_MILLISECONDS = 100;

        public HomeAutomatedUITests()
        {
            homeViewModel = new HomeViewModel();
            _driver = new ChromeDriver();
            actions = new Actions(_driver);
            javaScriptExecutor = (IJavaScriptExecutor)_driver;
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
        public void HomeViewStoplightBecomesGreenAfterAcceptIsClicked()
        {
            // Arrange:
            SubmitRegistrationForm();
            IWebElement stoplightElement = FindElementByIdWithWaitTimer(homeViewModel.StoplightId);
            IWebElement button = FindElementByIdWithWaitTimer(homeViewModel.AcceptId);

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
            IWebElement containerElement = FindElementByIdWithWaitTimer("container1");
            IReadOnlyCollection<IWebElement> childElements = containerElement.FindElements(By.XPath(".//*"));

            // Assert:
            Assert.NotNull(containerElement);
            Assert.True(containerElement.Displayed);
            Assert.True(containerElement.Enabled);
            Assert.Contains(containerElement.GetAttribute("class"), "container-fluid bg-1 text-center w3-animate-right");
            Assert.NotNull(childElements);
        }

        [Fact]
        public void HomeViewRegistrationFormProvidesErrorFeedbackTextIfNameIsEmpty()
        {
            // Arrange:
            SubmitRegistrationForm(string.Empty);

            // Act:
            var element = FindElementByIdWithWaitTimer("feedback");

            // Assert:
            Assert.NotNull(element);
            Assert.True(element.Displayed);
            Assert.True(element.Enabled);
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
            var element = FindElementByIdWithWaitTimer(ViewConstants.HealthDeclarationModalId);

            // Assert:
            Assert.NotNull(element);
            Assert.True(element.Displayed);
            Assert.True(element.Enabled);
        }

        [Fact]
        public void HomeViewHealthDeclarationFormFormatIsCorrect()
        {
            // Arrange:
            SubmitRegistrationForm();

            // Act & Assert:
            AssertWebElementIsVisibleById(ViewConstants.HealthDeclarationModalId);
            IWebElement healthDeclarationHeader = AssertWebElementIsVisibleById(ViewConstants.HealthDeclarationHeaderId);
            Assert.Contains(homeViewModel.HealthDeclarationHeader, healthDeclarationHeader.Text);
            IWebElement healthDeclarationParagraph = AssertWebElementIsVisibleById(ViewConstants.HealthDeclarationParagraphId);
            Assert.True(healthDeclarationParagraph.Text.Equals(homeViewModel.HealthDeclarationParagraph));
            IWebElement acceptButton = AssertWebElementIsVisibleById(ViewConstants.AcceptId);
            Assert.True(acceptButton.Text.Equals(homeViewModel.AcceptText));
            IWebElement declineButton = AssertWebElementIsVisibleById(ViewConstants.DeclineId);
            Assert.True(declineButton.Text.Equals(homeViewModel.DeclineText));
        }

        [Fact]
        public void HomeViewDefinitionsContainerExists()
        {
            // Arrange: (see class constructor)

            // Act:
            IWebElement containerElement = AssertWebElementIsVisibleById(homeViewModel.DefinitionsContainerId);

            // Assert:
            Assert.Contains(containerElement.GetAttribute("class"), "container-fluid bg-3 text-center w3-animate-left");
        }

        [Fact]
        public void HomeViewDefinitionsContainerContainsGreenLightDefinition()
        {
            // Arrange: (see class constructor)

            // Act:
            IWebElement element = AssertWebElementIsVisibleById(homeViewModel.GreenLightDefinitionId);

            // Assert:
            Assert.Contains(homeViewModel.GreenLightDefinition, _driver.PageSource);
        }

        [Fact]
        public void HomeViewDefinitionsContainerContainsYellowLightDefinition()
        {
            // Arrange: (see class constructor)

            // Act:
            IWebElement element = AssertWebElementIsVisibleById(homeViewModel.YellowLightDefinitionId);

            // Assert:
            Assert.Contains(homeViewModel.YellowLightDefinition, _driver.PageSource);
        }

        [Fact]
        public void HomeViewDefinitionsContainerContainsRedLightDefinition()
        {
            // Arrange: (see class constructor)

            // Act:
            IWebElement element = AssertWebElementIsVisibleById(homeViewModel.RedLightDefinitionId);

            // Assert:
            Assert.Contains(homeViewModel.RedLightDefinition, _driver.PageSource);
        }

        [Fact]
        public void HomeViewContainsAcceptElement()
        {
            // Arrange:
            SubmitRegistrationForm();

            // Act:
            IWebElement acceptButton = FindElementByIdWithWaitTimer(homeViewModel.AcceptId);

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

        [Fact]
        public void DemoUserAbleToNavigateWorkflowToAcceptHealthDeclaration()
        {
            // Arrange:
            Actions action = new Actions(_driver);
            SubmitRegistrationForm(name: null, DEMO_USER_DELAY_MILLISECONDS);
            IWebElement stoplightElement = FindElementByIdWithWaitTimer(homeViewModel.StoplightId);

            // Act:
            MoveToElementById(homeViewModel.AcceptId, DEMO_USER_DELAY_MILLISECONDS);
            MoveToElementById(homeViewModel.DeclineId, DEMO_USER_DELAY_MILLISECONDS);
            MoveToElementById(homeViewModel.AcceptId, DEMO_USER_DELAY_MILLISECONDS);
            ClickWithWaitTimer(FindElementByIdWithWaitTimer(homeViewModel.AcceptId), DEMO_USER_DELAY_MILLISECONDS);

            // Assert:
            Thread.Sleep(10 * DEMO_USER_DELAY_MILLISECONDS);
            Assert.NotNull(stoplightElement);
            Assert.Contains("green", stoplightElement.GetAttribute("class"));
        }

        private void MoveToElementById(string elementId, int userDelayMilliseconds = 0)
        {
            IWebElement element = FindElementByIdWithWaitTimer(elementId);
            Thread.Sleep(userDelayMilliseconds);
            if (element != null)
            {
                actions.MoveToElement(element).Build().Perform();
            }
            Thread.Sleep(userDelayMilliseconds);
        }

        private IWebElement AssertWebElementIsVisibleById(string elementId)
        {
            IWebElement element = FindElementByIdWithWaitTimer(elementId);
            Assert.NotNull(element);
            Assert.True(element.Displayed);
            Assert.True(element.Enabled);
            return element;
        }

        private void SubmitRegistrationForm(string name = null, int userDelayMilliseconds = 0)
        {
            IWebElement nameInputElement = FindElementByIdWithWaitTimer(ViewConstants.NameId);
            IWebElement emailInputElement = FindElementByIdWithWaitTimer(ViewConstants.EmailId);
            IWebElement submitButtonElement = FindElementByIdWithWaitTimer(ViewConstants.BtnAcceptId);
            Thread.Sleep(userDelayMilliseconds);
            if (name == null)
            {
                nameInputElement.SendKeys(USER_FULL_NAME);
            }
            else
            {
                nameInputElement.SendKeys(name);
            }
            Thread.Sleep(userDelayMilliseconds);
            emailInputElement.SendKeys(USER_EMAIL);
            Thread.Sleep(userDelayMilliseconds);
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

        private void ClickWithWaitTimer(IWebElement element, int userDelayMilliseconds = 0)
        {
            Thread.Sleep(userDelayMilliseconds);
            element.Click();
            Thread.Sleep(5 * WAIT_TIME_IN_MILLISECONDS);
        }
    }
}
