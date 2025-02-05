

using Application.ChatAI.Responses;
using Application.Common.DTO;
using MediatR;

namespace Application.ChatAI.Commands;

public class CreateChatResponseCommand(CreateChatResponseDto response) : IRequest<SaveChatResponse>
{
    public CreateChatResponseDto Response => response;
}
