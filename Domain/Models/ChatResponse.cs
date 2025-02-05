namespace Domain.Models;

public class ChatResponse
{
    public int Id { get; set; }
    public int MessageId { get; set; }
    public string BotResponse { get; set; } = string.Empty;
    public int? Rating { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public ChatMessage Message { get; set; } = null!;
}
