using WebApi.Domain.Models;
using WebApi.Domain.Repositories;

namespace WebApi.Data.Repositories
{
    public class CallbackStatusRepository : ICallbackStatusRepository
    {
        public async Task<bool> Create(PostModel model)
        {
            //TODO ADD logic to save status
            return true;
        }

        public async Task<CallBackStatusModel> Get(string id)
        {
            //TODO get from storage
            return new CallBackStatusModel()
            {
                Id = id,
                Status = "STARTED",
                Details = "some details",
                Body = "original body",
                CreatedDate = DateTime.Now.AddDays(-8),
                UpdatedDate = DateTime.Now.AddDays(-1)};
        }

        public async Task<bool> Update(PutModel model)
        {
            //TODO ADD logic to update by id status
            return true;
        }
    }
}
