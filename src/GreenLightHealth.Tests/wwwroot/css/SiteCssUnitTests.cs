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
            "    color: #ffffff;",
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
            "    background-color: #bad1b6;",
            "    color: #555555;",
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
            "    background-color: #eadbb0;",
            "    color: #555555;",
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
            "    background-color: #e0a39f;",
            "    color: #555555;",
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
            "    height: 350px;",
            "    width: 350px;",
            "    background-color: #ff0000;",
            "    border-radius: 50%;",
            "    display: inline-block;",
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
            "}");

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(SiteCss.Contains(expectedStyling));
        }
    }
}
