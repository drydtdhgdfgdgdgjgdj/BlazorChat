namespace BlazorChat.Dto.Requests
{
    public class ChatMessageResult
    {
        public required string Author { get; set; }
        public required string Message { get; set; }
        public required string Channel { get; set; }
    }
}
