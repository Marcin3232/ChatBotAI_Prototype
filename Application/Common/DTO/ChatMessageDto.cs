using Application.Common.Interfaces.Mappings;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.DTO;

public class ChatMessageDto :IMapFrom<ChatMessage>
{
    public int Id { get; set; }
    public int UserId { get; set; } = 0;
    public UserDto User { get; set; } = null!;

    public string UserMessage { get; set; } = string.Empty;
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public List<ChatResponseDto> Responses { get; set; } = new();
}
