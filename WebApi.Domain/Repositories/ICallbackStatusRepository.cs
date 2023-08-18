using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories
{
    public interface ICallbackStatusRepository
    {
        Task<bool> Create(PostModel model);
        Task<bool> Update(PutModel model);
        Task<CallBackStatusModel> Get(string id);
    }
}
