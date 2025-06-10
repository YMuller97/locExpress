namespace LocExpressApi.Shared.Models
{
    public class Message
    {
        public int SenderId { get; set; }
        public DateTime Timestamp { get; set; }
        public string Content { get; set; }
    }
}
