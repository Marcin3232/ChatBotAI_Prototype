using Application.Common.Interfaces.Repositories;
using Domain.Models;
using Infrastructure.DB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class ChatResponseDbRepository(IApplicationDbContext databaseContext) : DbRepository<ChatResponse>(databaseContext), IChatResponseRepository
{
    public Task<ChatResponse?> GetChatResponseAsync(int id, CancellationToken cancellationToken = default)
        => DatabaseContext.Responses
        .Include(x => x.Message)
        .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

    public async Task<ChatResponse> SaveAsync(ChatResponse chatResponse, CancellationToken cancellationToken = default)
        => await SaveAsync(chatResponse, chatResponse.Id, cancellationToken);
}
