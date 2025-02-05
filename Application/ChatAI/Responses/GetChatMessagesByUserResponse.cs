using Application.Common.DTO;

namespace Application.ChatAI.Responses;

public class GetChatMessagesByUserResponse
{
    public IEnumerable<ChatMessageDto> Messages { get; set; } = [];
}
