using Microsoft.Extensions.Configuration;
using Moq;
using WebApi.Domain.Models;
using WebApi.Services;

namespace WebApi.Tests.Services
{
    public class ThirdPartyHandlerServiceTest
    {

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public async Task CallEndpointMethod_ValidRequest_ReturnsServiceResponse()
        {
            // Arrange
            var configuration = new Mock<IConfiguration>();
            configuration.Setup(c => c["ThirdPartyServiceSettings:EndpointUri"]).Returns("https://example.com/api/thirdparty");

            var request = new ThirdPartySumbitRequest
            {
                Body = "SomeRequestBody"
            };
            var thirdPartyService = new ThirdPartyHandlerService(configuration.Object)
            {
                
            };
            // Act
            var result = await thirdPartyService.CallEndpoint(request);

            // Assert
            Assert.IsTrue(result.Result is string);
            // Add more assertions as needed
        }

    }
}
