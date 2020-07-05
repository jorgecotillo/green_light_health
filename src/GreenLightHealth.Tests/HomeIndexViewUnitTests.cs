using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace GreenLightHealth.Tests
{
    [TestClass]
    public class HomeIndexUnitTests
    {
        string IndexViewText;

        [TestInitialize]
        public void Initialize()
        {
            var directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            var path = Path.Combine(directory, "Views/Home/Index.cshtml");
            IndexViewText = File.ReadAllText(path);
        }

        [TestMethod]
        public void ErrorViewExists()
        {
            // Arrange: (see class constructor)

            // Act: (see class constructor)

            // Assert:
            Assert.IsNotNull(IndexViewText);
        }

        [TestMethod]
        public void ContainsStopLightElement()
        {
            // Arrange:
            string expectedHtml = "<span class=\"stoplight\"></span>";

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(IndexViewText.Contains(expectedHtml));
        }

        [TestMethod]
        public void FirstContainerElementExists()
        {
            // Arrange:
            string expectedHtml = "<div class=\"container-fluid bg-1 text-center\">";

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(IndexViewText.Contains(expectedHtml));
        }

        [TestMethod]
        public void SecondContainerElementExists()
        {
            // Arrange:
            string expectedHtml = "<div class=\"container-fluid bg-2 text-center\">";

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(IndexViewText.Contains(expectedHtml));
        }

        [TestMethod]
        public void ThirdContainerElementExists()
        {
            // Arrange:
            string expectedHtml = "<div class=\"container-fluid bg-3 text-center\">";

            // Act: (see class constructor)

            // Assert:
            Assert.IsTrue(IndexViewText.Contains(expectedHtml));
        }
    }
}
