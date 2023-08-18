using WebApi.Domain.Models.Enums;

namespace WebApi.Domain.Models
{
    public class Message
    {
        public ResponseMessageType Type { get; set; }
        public string Content { get; set; }
    }
}
