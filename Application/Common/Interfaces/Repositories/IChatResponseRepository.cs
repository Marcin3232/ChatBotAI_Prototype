using Domain.Models;

namespace Application.Common.Interfaces.Repositories
{
    public interface IChatResponseRepository
    {
        Task<ChatResponse?> GetChatResponseAsync(int id, CancellationToken cancellationToken = default);
        Task<ChatResponse> SaveAsync(ChatResponse chatResponse, CancellationToken cancellationToken = default);
    }
}