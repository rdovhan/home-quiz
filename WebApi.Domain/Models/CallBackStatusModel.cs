namespace WebApi.Domain.Models
{
    public class CallBackStatusModel
    {
        public string Id { get; set; }
        public string Status { get; set; }
        public string Details { get; set; }
        public string Body { get; set; }

        public DateTime UpdatedDate { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
