using GreenLightHealth.Client.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace GreenLightHealth.Tests
{
    [TestClass]
    public class HomeControllerUnitTests
    {
        private HomeController controller;

        [TestInitialize]
        public void Initialize()
        {
            var logger = new Mock<ILogger<HomeController>>();

            controller = new HomeController(logger.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
        }

        [TestMethod]
        public void ErrorViewExists()
        {
            // Arrange: (see test class constructor)

            // Act:
            var result = controller.Error() as ViewResult;

            // Assert:
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void IndexViewExists()
        {
            // Arrange: (see test class constructor)

            // Act:
            ViewResult viewResult = controller.Index() as ViewResult;

            // Assert:
            Assert.IsNotNull(viewResult);
        }
    }
}
