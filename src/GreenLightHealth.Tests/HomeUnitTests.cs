using GreenLightHealth.Client.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Threading.Tasks;

namespace GreenLightHealth.Tests
{
    [TestClass]
    public class HomeUnitTests
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
        public void CanAccessError_ShouldPass()
        {
            var result = controller.Error() as ViewResult;
            Assert.IsNotNull(result);
        }
    }
}
