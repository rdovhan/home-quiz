using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Domain.Models;

namespace WebApi.Domain.Services
{
    public interface IThirdPartyHandlerService
    {
        Task<ServiceResponse<string>> CallEndpoint(ThirdPartySumbitRequest request);

    }
}
