namespace ArtisanRoots.API.Shared.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);

    Task<TEntity?> FindByIdAsync(int id);

    void Remove(TEntity entity);

    Task<IEnumerable<TEntity>> ListAsync();

}

