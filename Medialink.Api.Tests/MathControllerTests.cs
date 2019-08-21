using Medialink.Api.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System.Net;

namespace Medialink.Api.Tests
{
    [TestFixture]
    public class MathControllerTests
    {
        private readonly MathController _mathController;
        public MathControllerTests()
        {
            _mathController = new MathController();
        }

        [Test]
        public void MathController_Add_ShouldReturn6()
        {

            var expected = "6";

            var actionResult = _mathController.Add(3, 3);
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var actual = okObjectResult.Value;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MathController_Multiply_ShouldReturn9()
        {
            var expected = "9";

            var actionResult = _mathController.Multiply(3, 3);
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var actual = okObjectResult.Value;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MathController_Divide_ShouldReturn1()
        {
            var expected = "1";

            var actionResult = _mathController.Divide(3, 3);
            var okObjectResult = actionResult as OkObjectResult;
            Assert.NotNull(okObjectResult);

            var actual = okObjectResult.Value;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void MathController_Divide_ShouldReturnBadRequest()
        {
            var actionResult = _mathController.Divide(3, 0);
            var statusCodeResult = actionResult as StatusCodeResult;
            Assert.AreEqual((int)HttpStatusCode.InternalServerError, statusCodeResult.StatusCode);
        }
    }
}