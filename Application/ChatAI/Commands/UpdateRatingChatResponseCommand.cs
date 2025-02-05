using Application.ChatAI.Responses;
using Application.Common.DTO;
using MediatR;

namespace Application.ChatAI.Commands;

public class UpdateRatingChatResponseCommand(UpdateRatingChatResponseDto updateRatingChatResponse) : IRequest<SaveChatResponse>
{
    public UpdateRatingChatResponseDto UpdateRatingChatResponse => updateRatingChatResponse;
}
