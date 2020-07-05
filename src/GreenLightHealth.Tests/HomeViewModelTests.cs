
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
            const string expected = "Accept";

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
            const string expected = "Decline";

            // Act:
            string actual = homeViewModel.DeclineText;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HealthDeclarationHeaderIsCorrect()
        {
            // Arrange:
            const string expected = "Are You Healthy?";

            // Act:
            string actual = homeViewModel.HealthDeclarationHeader;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HealthDeclarationParagraphIsCorrect()
        {
            // Arrange:
            const string expected = "For the health and safety of our community, declaration of illness is required. Be sure that the information you'll give is accurate and complete. Please get immediate medical attention if you have any of the COVID-19 signs.";

            // Act:
            string actual = homeViewModel.HealthDeclarationParagraph;

            // Assert:
            Assert.AreEqual(expected, actual);
        }
    }
}
