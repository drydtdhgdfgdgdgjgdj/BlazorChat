namespace BlazorChat.Dto.Results
{
    public class ChatMessageResult
    {
        public int Id { get; set; }
        public required string Author { get; set; }
        public required string Message { get; set; }
        public required string Channel { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
