using Medialink.Lib.Infrastructure.ConnectionFactory;
using Medialink.Lib.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Moq;
using NUnit.Framework;
using RestSharp;
using System;
using System.Net;

namespace Medialink.Lib.Tests
{
    [TestFixture]
    public class MathWebClientTests
    {
        private readonly MathWebClient _webClientTest;
        private readonly Mock<ILogger<MathWebClient>> _mockLogger;

        public MathWebClientTests()
        {
            _mockLogger = new Mock<ILogger<MathWebClient>>();
            var connectionFactoryMock = new Mock<IDatabaseConnectionFactory>();
            var db = new InMemoryDatabase();
            connectionFactoryMock.Setup(c => c.GetConnection()).Returns(db.OpenConnection());

            var result = new ImportantObjectRepository(connectionFactoryMock.Object);
            _webClientTest = new MathWebClient(MockRestClient(HttpStatusCode.OK, default(int)), result, _mockLogger.Object);
        }

        public static IRestClient MockRestClient(HttpStatusCode httpStatusCode, int data) 
        {
           var response = new Mock<IRestResponse<int>>();
            response.Setup(_ => _.StatusCode).Returns(httpStatusCode);
            response.Setup(_ => _.Data).Returns(data);

            var mockIRestClient = new Mock<IRestClient>();
            mockIRestClient
              .Setup(x => x.Execute(It.IsAny<IRestRequest>()))
              .Returns(response.Object);
            return mockIRestClient.Object;
        }

        [TestCase(1, 2)]
        [TestCase(3, 5)]
        [TestCase(6, 2)]
        public void Client_Add_Should_Return_CorrectValues(int a, int b)
        {
            var expected = a + b; 
            
            var resultValue = _webClientTest.Add(a, b);

            Assert.AreEqual(expected, resultValue);
        }

        [TestCase(1, 2)]
        [TestCase(3, 5)]
        [TestCase(6, 2)]
        public void Client_Multiply_Should_Return_CorrectValues(int a, int b)
        {
            var expected = a * b;

            var resultValue = _webClientTest.Multiply(a, b);

            Assert.AreEqual(expected, resultValue);
        }

        [TestCase(1, 2)]
        [TestCase(3, 5)]
        [TestCase(6, 2)]
        public void Client_Divide_Should_Return_CorrectValues(int a, int b)
        {
            var expected = a / b;

            var resultValue = _webClientTest.Divide(a, b);

            Assert.AreEqual(expected, resultValue);
        }

        [Test]
        public void Client_Add_Should_Log_Once()
        {
            var resultValue = _webClientTest.Add(5,5);

            _mockLogger.Verify(x => x.Log(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<FormattedLogValues>(), It.IsAny<Exception>(), It.IsAny<Func<object, Exception, string>>()), Times.Once);
        }
    }
}