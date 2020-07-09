
using GreenLightHealth.Client.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreenLightHealth.Tests
{
    [TestClass]
    public class HomeViewModelTests
    {
        private HomeViewModel homeViewModel;
        public HomeViewModelTests()
        {
            homeViewModel = new HomeViewModel();
        }

        [TestMethod]
        public void StoplightIdIsCorrect()
        {
            // Arrange:
            const string expected = "stoplight";

            // Act:
            string actual = homeViewModel.StoplightId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AcceptIdIsCorrect()
        {
            // Arrange:
            const string expected = "accept";

            // Act:
            string actual = homeViewModel.AcceptId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AcceptTextIsCorrect()
        {
            // Arrange:
            const string expected = "No";

            // Act:
            string actual = homeViewModel.AcceptText;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeclineIdIsCorrect()
        {
            // Arrange:
            const string expected = "decline";

            // Act:
            string actual = homeViewModel.DeclineId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeclineTextIsCorrect()
        {
            // Arrange:
            const string expected = "Yes";

            // Act:
            string actual = homeViewModel.DeclineText;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HealthDeclarationHeaderIsCorrect()
        {
            // Arrange:
            const string expected = "Health Declaration";

            // Act:
            string actual = homeViewModel.HealthDeclarationHeader;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HealthDeclarationParagraphIsCorrect()
        {
            // Arrange:
            const string expected = "For the health and safety of our community, your declaration of health is required. Please get immediate medical attention if you have any signs of COVID-19. Do you, to the best of your knowledge, have any symptoms or positive test results for COVID-19?";

            // Act:
            string actual = homeViewModel.HealthDeclarationParagraph;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DefinitionsContainerIdIsCorrect()
        {
            // Arrange:
            const string expected = "definitions-container";

            // Act:
            string actual = homeViewModel.DefinitionsContainerId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GreenLightDefinitionIdIsCorrect()
        {
            // Arrange:
            const string expected = "greenlight-definition";

            // Act:
            string actual = homeViewModel.GreenLightDefinitionId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GreenLightDefinitionDefinitionIdIsCorrect()
        {
            // Arrange:
            const string expected = "You have declared that you are free of symptoms and have no positive test results. Additionally, your contact history is clear of others who are now marked red. Please be careful and follow all regulatory guidelines to continue to protect yourself and others from illness.";

            // Act:
            string actual = homeViewModel.GreenLightDefinition;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void YellowLightDefinitionIdIsCorrect()
        {
            // Arrange:
            const string expected = "yellowlight-definition";

            // Act:
            string actual = homeViewModel.YellowLightDefinitionId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void YellowLightDefinitionDefinitionIdIsCorrect()
        {
            // Arrange:
            const string expected = "You have declared that you are free of symptoms and have no positive test results. However, you may have been exposed through contact to others who are now reporting symptoms of illness. Please seek consultation from medical experts to protect yourself and others.";

            // Act:
            string actual = homeViewModel.YellowLightDefinition;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RedLightDefinitionIdIsCorrect()
        {
            // Arrange:
            const string expected = "redlight-definition";

            // Act:
            string actual = homeViewModel.RedLightDefinitionId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RedLightDefinitionDefinitionIdIsCorrect()
        {
            // Arrange:
            const string expected = "You have self-declared that you have symptoms or a positive test result. You could be at risk or put others at risk. Please seek consultation from medical experts to protect yourself and others if you have symptoms or a positive test result.";

            // Act:
            string actual = homeViewModel.RedLightDefinition;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserNameIdIsCorrect()
        {
            // Arrange:
            const string expected = "welcome-text";

            // Act:
            string actual = homeViewModel.UserNameId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }
    }
}
