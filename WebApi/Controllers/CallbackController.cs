using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Services;

namespace WebApi.Controllers
{
    [ApiController]
    //[Authorize] //TODO : currently out of scope
    public class CallbackController : Controller
    {
        private ICallbackServiceHandler _callbackHandlerService;
        public CallbackController(ICallbackServiceHandler callbackHandlerService)
        {
            _callbackHandlerService = callbackHandlerService;
        }

        [HttpPost("callback/{id}")]
        public async Task<IActionResult> CallBackPost(string id, [FromBody] CallbackPostModel callbackPostModel)
        {
            await _callbackHandlerService.HandlePost(new PostModel() { Id = id, Body = callbackPostModel.Body });
            return NoContent(); // StatusCode(204);
        }

        [HttpPut("callback/{id}")]
        public async Task<IActionResult> CallBackPut(string id, [FromBody] CallbackPutModel callBackPutModel)
        {
            await _callbackHandlerService.HandlePut(new PutModel() { Id = id, Status = callBackPutModel.Status, Details = callBackPutModel.Details });
            return NoContent() ;
        }

        [HttpGet("status")]
        public async Task<IActionResult> CallBackGet(string id)
        {
            var result = await _callbackHandlerService.HandleGet(id);
            return Ok(result.Result);
        }
    }
}
