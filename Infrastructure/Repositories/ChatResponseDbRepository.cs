using Application.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.DB;

namespace Infrastructure.Repositories;

public class ChatResponseDbRepository(IApplicationDbContext databaseContext) : DbRepository<ChatResponse>(databaseContext), IChatResponseRepository
{
    public async Task<ChatResponse> SaveAsync(ChatResponse chatResponse, CancellationToken cancellationToken = default)
        => await SaveAsync(chatResponse, chatResponse.Id, cancellationToken);
}
