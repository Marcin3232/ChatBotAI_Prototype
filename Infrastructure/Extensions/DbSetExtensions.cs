using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Extensions;

public static class DbSetExtensions
{
    /// <summary>
    /// Allows to pass key as int directly with cancellation token
    /// </summary>
    /// <typeparam name="T">Entity type</typeparam>
    /// <param name="dbSet">DbSet to search</param>
    /// <param name="id">Entity key</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>Found entity or null</returns>
    public static async ValueTask<T?> FindAsync<T>(this DbSet<T> dbSet, long id, CancellationToken cancellationToken = default) where T : class
    {
        return await dbSet.FindAsync([id], cancellationToken);
    }
}
