using Application.Common.Interfaces.Mappings;
using Domain.Models;

namespace Application.Common.DTO;

public class ChatResponseDto : IMapFrom<ChatResponse>
{
    public int Id { get; set; }
    public int MessageId { get; set; }
    public string BotResponse { get; set; } = string.Empty;
    public int? Rating { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public ChatMessageDto Message { get; set; } = null!;
}
