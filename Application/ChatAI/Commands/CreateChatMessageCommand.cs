using Application.ChatAI.Responses;
using Application.Common.DTO;
using MediatR;

namespace Application.ChatAI.Commands;

public class CreateChatMessageCommand(CreateChatMessageDto message) : IRequest<SaveChatMessageResponse>
{
    public CreateChatMessageDto Message => message;
}
