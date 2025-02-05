using Application.ChatAI.Responses;
using Application.Common.DTO;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.ChatAI.Commands;

public class UpdateRatingChatResponseCommandHandler(IMapper mapper, IChatResponseRepository chatResponseRepository)
    : IRequestHandler<UpdateRatingChatResponseCommand, SaveChatResponse>
{
    private readonly IMapper _mapper = mapper;
    private IChatResponseRepository _chatResponseRepository = chatResponseRepository;

    public async Task<SaveChatResponse> Handle(UpdateRatingChatResponseCommand request, CancellationToken cancellationToken)
    {
        var chatResponse = await _chatResponseRepository.GetChatResponseAsync(request.UpdateRatingChatResponse.Id, cancellationToken);
        if (chatResponse is null)
            return new();

        chatResponse.Rating = request.UpdateRatingChatResponse.Rating;
        var result = await _chatResponseRepository.SaveAsync(chatResponse, cancellationToken);
        return new()
        {
            ChatResponse = _mapper.Map<ChatResponseDto>(result)
        };
    }
}
