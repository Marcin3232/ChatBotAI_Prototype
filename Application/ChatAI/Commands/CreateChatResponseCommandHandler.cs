using Application.ChatAI.Responses;
using Application.Common.DTO;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.ChatAI.Commands;

public class CreateChatResponseCommandHandler(IMapper mapper, IChatResponseRepository chatResponseRepository) : IRequestHandler<CreateChatResponseCommand, SaveChatResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IChatResponseRepository _chatResponseRepository = chatResponseRepository;

    public async Task<SaveChatResponse> Handle(CreateChatResponseCommand request, CancellationToken cancellationToken)
    {
        var response = _mapper.Map<ChatResponse>(request.Response);
        var result = await _chatResponseRepository.SaveAsync(response, cancellationToken);
        return new()
        {
            ChatResponse = _mapper.Map<ChatResponseDto>(result)
        };
    }
}
