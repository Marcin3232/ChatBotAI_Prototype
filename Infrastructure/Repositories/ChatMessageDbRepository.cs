using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChatMessageDbRepository(IApplicationDbContext databaseContext) : DbRepository<ChatMessage>(databaseContext), IChatMessageRepository
{
    public async Task<IEnumerable<ChatMessage>> GetByUserAsync(int userId, CancellationToken cancellationToken = default)
        => await DatabaseContext.Messages
        .Where(x => x.UserId == userId)
        .Include(x => x.User)
        .Include(x => x.Responses)
        .ToListAsync(cancellationToken);

    public async Task<ChatMessage> SaveAsync(ChatMessage chatMessage, CancellationToken cancellationToken = default)
        => await SaveAsync(chatMessage, chatMessage.Id, cancellationToken);
}
