using Application.Common.Interfaces.Mappings;
using Domain.Models;

namespace Application.Common.DTO;

public class CreateChatResponseDto : IMapTo<ChatResponse>
{
    public int MessageId { get; set; }
    public string BotResponse { get; set; } = string.Empty;
}
