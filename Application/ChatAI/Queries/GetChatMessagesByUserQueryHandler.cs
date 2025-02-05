using Application.ChatAI.Responses;
using Application.Common.DTO;
using Application.Common.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Application.ChatAI.Queries;

public class GetChatMessagesByUserQueryHandler(IMapper mapper, IChatMessageRepository chatMessageRepository) : IRequestHandler<GetChatMessagesByUserQuery, GetChatMessagesByUserResponse>
{
    private readonly IMapper _mapper = mapper;
    private readonly IChatMessageRepository _chatMessageRepository = chatMessageRepository;

    public async Task<GetChatMessagesByUserResponse> Handle(GetChatMessagesByUserQuery request, CancellationToken cancellationToken)
    {
        var result = await _chatMessageRepository.GetByUserAsync(request.Id, cancellationToken);
        return new()
        {
            Messages = _mapper.Map<IEnumerable<ChatMessageDto>>(result)
        };
    }
}
