

using Application.ChatAI.Responses;
using Application.Common.DTO;
using MediatR;

namespace Application.ChatAI.Commands;

public class UpdateChatResponseCommand(UpdateChatResponseDto response) : IRequest<SaveChatResponse>
{
    public UpdateChatResponseDto Response => response;
}
