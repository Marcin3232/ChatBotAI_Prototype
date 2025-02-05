using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Configuration;

namespace Infrastructure.DB;

public class ChatAIDbContext(DbContextOptions<ChatAIDbContext> options) : DbContext(options), IApplicationDbContext
{
    private const int _smallStringLength = 128;
    private const int _maxStringLength = -1;

    private readonly DbContextOptions<ChatAIDbContext> _options = options;

    public DbSet<User> Users { get; set; }
    public DbSet<ChatMessage> Messages { get; set; }
    public DbSet<ChatResponse> Responses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BuildModelChatMessage(modelBuilder);
        BuildModelChatResponse(modelBuilder);
        BuildModelUsers(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
    }

    private void BuildModelUsers(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Name)
                .HasMaxLength(_smallStringLength);
        });
    }

    private void BuildModelChatMessage(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatMessage>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.UserId)
                .IsRequired();

            entity.Property(x => x.UserMessage)
                .HasMaxLength(_maxStringLength);
        });
    }

    private void BuildModelChatResponse(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ChatResponse>(entity =>
        {
            entity.HasKey(x => x.Id);

            entity.Property(x => x.BotResponse)
                .HasMaxLength(_maxStringLength);

            entity.Property(x => x.MessageId)
                .IsRequired();
        });
    }
}
