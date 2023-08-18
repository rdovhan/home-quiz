using System;
using WebApi.Domain.Models;
using WebApi.Domain.Models.Enums;

namespace WebApi.Domain.Services
{
    public class ServiceResponse<T>
    {

        public ServiceResponse()
        {
            Messages = new List<Message>();
            IsSuccess = true;
        }

        public bool IsSuccess { get; set; }
        public T Result { get; set; }
        public List<Message> Messages { get; }


        public ServiceResponse<T> WithErrors(params string[] messages)
        {
            foreach (var message in messages)
            {
                Messages.Add(new Message
                {
                    Type = ResponseMessageType.Error,
                    Content = message
                });
            }
            IsSuccess = Messages != null && !Messages.Any(m => m.Type.Equals(ResponseMessageType.Error));
            return this;
        }


        public ServiceResponse<T> WithWarnings(params string[] messages)
        {
            foreach (var message in messages)
            {
                Messages.Add(new Message
                {
                    Type = ResponseMessageType.Warning,
                    Content = message
                });
            }
            return this;
        }


        public ServiceResponse<T> SendToLog(params string[] messages)
        {
            return this;
        }


        public ServiceResponse<T> Merge(params IEnumerable<Message>[] messages)
        {
            foreach (var subset in messages)
                this.Messages.AddRange(subset);

            return this;
        }
    }
}
