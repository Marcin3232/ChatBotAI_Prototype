namespace Domain.Models;


public class ChatMessage
{
    public int Id { get; set; }
    public int UserId { get; set; } = 0;
    public User User { get; set; } = null!;

    public string UserMessage { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public List<ChatResponse> Responses { get; set; } = new();
}

