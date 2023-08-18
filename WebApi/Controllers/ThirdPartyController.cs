using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] //currently out of scope
    public class ThirdPartyCallController : Controller
    {
        private IThirdPartyHandlerService _thirdPartyHandlerService;

        public ThirdPartyCallController(IThirdPartyHandlerService thirdPartyHandlerService)
        {
            _thirdPartyHandlerService = thirdPartyHandlerService;
        }

        [HttpPost]
        public async Task<IActionResult> Submit([FromBody] ThirdPartySumbitRequest requestModel)
        {
           var serviceResponse =  await _thirdPartyHandlerService.CallEndpoint(requestModel);

            return Ok(serviceResponse.Result);
        }
    }
}
