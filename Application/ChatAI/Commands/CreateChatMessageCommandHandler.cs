using Application.ChatAI.Responses;
using Application.Common.DTO;
using Application.Common.Interfaces.Repositories;
using Application.Common.Interfaces.Services;
using AutoMapper;
using Domain.Models;
using MediatR;

namespace Application.ChatAI.Commands;

public class CreateChatMessageCommandHandler(IMapper mapper, IChatMessageRepository chatMessageRepository, IChatAiResponseService chatAiResponseService) : IRequestHandler<CreateChatMessageCommand, SaveChatMessageResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IChatMessageRepository _chatMessageRepository = chatMessageRepository;
    private readonly IChatAiResponseService _chatAiResponseService = chatAiResponseService;

    public async Task<SaveChatMessageResponse> Handle(CreateChatMessageCommand request, CancellationToken cancellationToken)
    {
        var message = _mapper.Map<ChatMessage>(request.Message);
        var generateResponse = new ChatResponse()
        {
            MessageId = message.Id,
            Message = message,
            BotResponse = _chatAiResponseService.GenerateRandomLoremIpsum(),

        };

        message.Responses.Add(generateResponse);

        var result = await _chatMessageRepository.SaveAsync(message, cancellationToken);
        var newMessage = await _chatMessageRepository.GetById(result.Id, cancellationToken);
        return new()
        {
            Message = _mapper.Map<ChatMessageDto>(newMessage)
        };
    }
}
