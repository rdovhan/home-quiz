using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Domain.Models
{
    public class ThirdPartyRequestContent
    {
        public string Body { get; set; }
        public string Callback { get; set; }
    }
}
