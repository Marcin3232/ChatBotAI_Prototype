using Application.Common.Interfaces.Mappings;
using Domain.Models;

namespace Application.Common.DTO;

public class CreateChatMessageDto : IMapTo<ChatMessage>
{
    public int UserId { get; set; } = 0;

    public string UserMessage { get; set; } = string.Empty;
}
