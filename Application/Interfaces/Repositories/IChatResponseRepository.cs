using Domain.Models;

namespace Application.Interfaces.Repositories
{
    public interface IChatResponseRepository
    {
        Task<ChatResponse> SaveAsync(ChatResponse chatResponse, CancellationToken cancellationToken = default);
    }
}