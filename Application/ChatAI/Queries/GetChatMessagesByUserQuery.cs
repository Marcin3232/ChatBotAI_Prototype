using Application.ChatAI.Responses;
using MediatR;

namespace Application.ChatAI.Queries;

public class GetChatMessagesByUserQuery(int id) : IRequest<GetChatMessagesByUserResponse>
{
    public int Id => id;
}
