using Application.ChatAI.Responses;
using Application.Common.DTO;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.ChatAI.Commands;

public class CreateChatMessageCommandHandler(IMapper mapper, IChatMessageRepository chatMessageRepository) : IRequestHandler<CreateChatMessageCommand, SaveChatMessageResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IChatMessageRepository _chatMessageRepository = chatMessageRepository;

    public async Task<SaveChatMessageResponse> Handle(CreateChatMessageCommand request, CancellationToken cancellationToken)
    {
        var message = _mapper.Map<ChatMessage>(request.Message);
        var result = await _chatMessageRepository.SaveAsync(message, cancellationToken);
        return new()
        {
            Message = _mapper.Map<ChatMessageDto>(message)
        };
    }
}
