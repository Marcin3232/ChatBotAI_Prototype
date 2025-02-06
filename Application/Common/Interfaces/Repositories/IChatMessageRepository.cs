using Domain.Models;

namespace Application.Common.Interfaces.Repositories;

public interface IChatMessageRepository
{
    Task<IEnumerable<ChatMessage>> GetByUserAsync(int userId, CancellationToken cancellationToken = default);
    Task<ChatMessage> GetById(int id, CancellationToken cancellationToken = default);
    Task<ChatMessage> SaveAsync(ChatMessage chatMessage, CancellationToken cancellationToken = default);
}