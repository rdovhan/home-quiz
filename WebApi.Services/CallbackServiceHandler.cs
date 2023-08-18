using WebApi.Domain.Models;
using WebApi.Domain.Repositories;
using WebApi.Domain.Services;

namespace WebApi.Services
{
    public class CallbackServiceHandler : BaseService, ICallbackServiceHandler
    {
        private readonly ICallbackStatusRepository _callbackStatusRepository;

        public CallbackServiceHandler(ICallbackStatusRepository callbackStatusRepository) { 

            _callbackStatusRepository = callbackStatusRepository;
        }
        public async Task<ServiceResponse<CallBackStatusModel>> HandleGet(string id)
        {
            var resultModel = await _callbackStatusRepository.Get(id);
            return Respond(resultModel);
        }

        public async Task<ServiceResponse<bool>> HandlePost(PostModel model)
        {
            var result = await _callbackStatusRepository.Create(model);
            return Respond(result);
        }

        public async Task<ServiceResponse<bool>> HandlePut(PutModel model)
        {
            var result= await _callbackStatusRepository.Update(model);
            return Respond(result);
        }
    }
}
