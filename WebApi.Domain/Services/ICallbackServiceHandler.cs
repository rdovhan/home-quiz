using WebApi.Domain.Models;

namespace WebApi.Domain.Services
{
    public interface ICallbackServiceHandler
    {
        Task<ServiceResponse<bool>> HandlePost(PostModel model);
        Task<ServiceResponse<bool>> HandlePut(PutModel model);
        Task<ServiceResponse<CallBackStatusModel>> HandleGet(string id);
    }
}
