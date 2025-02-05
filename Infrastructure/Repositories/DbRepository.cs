using Infrastructure.DB;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Extensions;

namespace Infrastructure.Repositories;

public abstract class DbRepository<TEntity>(IApplicationDbContext databaseContext) where TEntity : class
{
    protected IApplicationDbContext DatabaseContext { get; } = databaseContext;

    protected virtual async Task<TEntity> SaveAsync(TEntity entity, int entityId, CancellationToken cancellationToken = default)
    {
        DbSet<TEntity> dbSet = DatabaseContext.Set<TEntity>();
        TEntity? dbEntity = await dbSet.FindAsync<TEntity>(entityId, cancellationToken);

        if (entityId == 0 || dbEntity == null)
        {
            EntityEntry<TEntity> entry = await dbSet.AddAsync(entity, cancellationToken);
            dbEntity = entry.Entity;
        }
        else
        {
            if (dbEntity != null && DatabaseContext.Entry(dbEntity).State != EntityState.Detached)
            {
                DatabaseContext.Entry(dbEntity).State = EntityState.Detached;
            }

            dbEntity = dbSet.Update(entity).Entity;
        }

        await DatabaseContext.SaveChangesAsync(cancellationToken);
        await AfterSaveAsync(entity, cancellationToken);
        DatabaseContext.ChangeTracker.Clear();

        return entity ?? throw new InvalidOperationException("Entity could not be saved");
    }

    protected virtual async Task AfterSaveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await Task.CompletedTask;
    }

    protected virtual async Task<bool> DeleteAsync(int entityId, CancellationToken cancellationToken = default)
    {
        DbSet<TEntity> dbSet = DatabaseContext.Set<TEntity>();
        var entity = await dbSet.FindAsync(entityId, cancellationToken);

        if (entity == null)
            return false;

        dbSet.Remove(entity);

        await DatabaseContext.SaveChangesAsync(cancellationToken);
        await AfterDeleteAsync(entity, cancellationToken);

        return true;
    }

    protected virtual Task AfterDeleteAsync(TEntity entity, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
