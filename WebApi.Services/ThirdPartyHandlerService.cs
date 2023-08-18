using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Services
{
    public class ThirdPartyHandlerService : BaseService, IThirdPartyHandlerService
    {
        private readonly IConfiguration _configuration;

        public ThirdPartyHandlerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<ServiceResponse<string>> CallEndpoint(ThirdPartySumbitRequest request)
        {
            string endpointUri = _configuration["ThirdPartyServiceSettings:EndpointUri"]; // referenced string could be constant 
            Guid correlationId = Guid.NewGuid();

            ThirdPartyRequestContent contentToSubmit = new()
            {
                Body = request.Body,
                Callback = "/callback/{id}"
            };

            LogDebugMessage($"call to endpoint {endpointUri} started with guid {correlationId}"); //timestamp

            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(contentToSubmit), Encoding.UTF8, "application/json");

                try
                {
                    //DISCUSS how to handle reposne
                    //do we need retry?
                    var response = await httpClient.PostAsync(endpointUri, content);
   
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
                catch (HttpRequestException ex)
                {
                    LogErrorWithException($"Error: {ex.Message}", correlationId, ex);
                }
   
                
            }
            LogDebugMessage($"call to endpoint {endpointUri} ended with guid {correlationId}");

            return Respond(correlationId.ToString());
        }
    }
}
