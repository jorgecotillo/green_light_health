using GreenLightHealth.Client.Constants;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GreenLightHealth.Tests.Constants
{
    [TestClass]
    public class ViewConstantsTests
    {
        [TestMethod]
        public void StoplightIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "stoplight";

            // Act:
            string actual = ViewConstants.StoplightId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StoplightGreenBulbIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "stoplightGreenBulb";

            // Act:
            string actual = ViewConstants.StoplightGreenBulbId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StoplightYellowBulbIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "stoplight-yellow-bulb";

            // Act:
            string actual = ViewConstants.StoplightYellowBulbId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void StoplightRedBulbIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "stoplight-red-bulb";

            // Act:
            string actual = ViewConstants.StoplightRedBulbId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void QrCodeIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "qrCode";

            // Act:
            string actual = ViewConstants.QrCodeId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HealthDeclarationHeaderIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "health-declaration";

            // Act:
            string actual = ViewConstants.HealthDeclarationHeaderId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HealthDeclarationParagraphIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "health-declaration-text";

            // Act:
            string actual = ViewConstants.HealthDeclarationParagraphId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void HealthDeclarationModalIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "health-declaration-form";

            // Act:
            string actual = ViewConstants.HealthDeclarationModalId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AcceptIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "accept";

            // Act:
            string actual = ViewConstants.AcceptId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeclineIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "decline";

            // Act:
            string actual = ViewConstants.DeclineId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RegistrationFormConstantIsCorrect()
        {
            // Arrange:
            const string expected = "registration-form";

            // Act:
            string actual = ViewConstants.RegistrationForm;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void NameIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "orangeForm-name";

            // Act:
            string actual = ViewConstants.NameId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void BtnAcceptIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "btn-accept";

            // Act:
            string actual = ViewConstants.BtnAcceptId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void EmailIdConstantIsCorrect()
        {
            // Arrange:
            const string expected = "orangeForm-email";

            // Act:
            string actual = ViewConstants.EmailId;

            // Assert:
            Assert.AreEqual(expected, actual);
        }
    }
}
