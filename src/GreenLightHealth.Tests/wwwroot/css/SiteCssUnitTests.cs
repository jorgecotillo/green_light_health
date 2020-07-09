using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace GreenLightHealth.Tests.wwwroot.css
{
    [TestClass]
    public class SiteCssUnitTests
    {
        private string SiteCss;

        [TestInitialize]
        public void Initialize()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(directory, "wwwroot/css/site.css");
            SiteCss = File.ReadAllText(path);
        }

        [TestMethod]
        public void SiteCssExists()
        {
            // Arrange: (see class constructor)

            // Act: (see class constructor)

            // Assert:
            Assert.IsNotNull(SiteCss);
        }

        [TestMethod]
        public void H2StylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            "h2 {",
            "    font-size: 2.5em;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void Bg1ClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".bg-1 {",
            "    background-color: #6fc1d1;",
            "    color: #f0f0f0;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void Bg2ClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".bg-2 {",
            "    background-color: #d1ad7b;",
            "    color: #f0f0f0;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void Bg3ClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".bg-3 {",
            "    background-color: #aaaaaa;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void MarginClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".margin {",
            "    margin-bottom: 45px;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void ContainerFluidClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".container-fluid {",
            "    padding-top: 70px;",
            "    padding-bottom: 70px;",
            "    min-width: 325px;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void NavbarClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".navbar {",
            "    padding-top: 15px;",
            "    padding-bottom: 15px;",
            "    border: 0;",
            "    border-radius: 0;",
            "    margin-bottom: 0;",
            "    font-size: 12px;",
            "    letter-spacing: 5px;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void StoplightClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".stoplight {",
            "    height: 400px;",
            "    max-width: 400px;",
            "    background-color: #aaaaaa;",
            "    border-radius: 50%;",
            "    border: 0.25em solid #d19c6f;",
            "    padding: 0.25em;",
            "    margin-bottom: 1em;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void StoplightCircleClassAfterStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".stoplight-circle::after {",
            "    border-right: 4px solid rgba(255, 255, 255, 0.6);",
            "    border-radius: 100%;",
            "    position: absolute;",
            "    content: ' ';",
            "    top: 15%;",
            "    left: 15%;",
            "    width: 75%;",
            "    height: 70%;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void StoplightContainerClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".stoplight-container {",
            "    background-color: #8f8f8f;",
            "    border: 0.25em solid #aaaaaa;",
            "    border-radius: 75px;",
            "    display: flex;",
            "    flex-direction: column;",
            "    align-items: center;",
            "    justify-content: space-around;",
            "    padding: 15px 0;",
            "    height: 100%;",
            "    width: 35%;",
            "    margin-left: auto;",
            "    margin-right: auto;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void StoplightCircleRedClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".stoplight-circle.red {",
            "    background-color: #e0746d;",
            "    box-shadow: 0 0 20px 5px #e0746d;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void StoplightCircleYellowClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".stoplight-circle.yellow {",
            "    background-color: #f5edab;",
            "    box-shadow: 0 0 20px 5px #f5edab;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void StoplightCircleGreenClassStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".stoplight-circle.green {",
            "    background-color: #6ed182;",
            "    box-shadow: 0 0 20px 5px #6ed182;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void BodyStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            "body {",
            "    font: 20px Montserrat, sans-serif;",
            "    line-height: 1.8;",
            "    color: #f5f6f7;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void ParagraphStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            "p {",
            "    font-size: 1em;",
            "    font-weight: bold;",
            "    color: #ffffff;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void StoplightCircleIsStyledCorrectly()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".stoplight-circle {",
            "    background-color: rgba(64, 64, 64, 0.3);",
            "    border-radius: 100%;",
            "    position: relative;",
            "    height: 80px;",
            "    width: 80px;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void InputStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            "input[type=text], input[type=email] {",
            "    font-weight: bold;",
            "    font-size: 1em;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void ModalHeaderStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".modal-header {",
            "    font-weight: bold;",
            "    font-size: 1.5em;",
            "    color: #6ed182;",
            "    margin-bottom: 0em;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void ModalBodyStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            ".modal-body {",
            "    margin-top: 1em;",
            "    margin-bottom: 1em;",
            "    font-size: 1em;",
            "    color: #646464;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }

        [TestMethod]
        public void ButtonStylingIsCorrect()
        {
            // Arrange:
            string expectedStyling =
            String.Join(
            Environment.NewLine,
            "button {",
            "    margin-left: 1em;",
            "    margin-right: 1em;",
            "    border: 0.1em solid #878787;",
            "    transition: all .2s ease-in-out;",
            "    padding: 1em;",
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }
    }
}
