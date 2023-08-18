using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Tests.Controllers
{
    public class ThirdPartyControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Submit_ValidRequest_ReturnsOk()
        {
            // Arrange
            var requestModel = new ThirdPartySumbitRequest();
            var expectedResult = "some-guid-string";
    

            var mockService = new Mock<IThirdPartyHandlerService>();
            mockService.Setup(service => service.CallEndpoint(requestModel))
                       .ReturnsAsync(new BaseService().Respond(expectedResult));

            var controller = new ThirdPartyCallController(mockService.Object);

            // Act
            var result = await controller.Submit(requestModel) as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.AreEqual(expectedResult, result.Value);
            Assert.That(result.StatusCode, Is.EqualTo(200));

        }
        
    }
}