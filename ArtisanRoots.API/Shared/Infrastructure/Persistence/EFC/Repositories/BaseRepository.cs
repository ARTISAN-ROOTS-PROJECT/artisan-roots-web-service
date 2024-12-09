using ArtisanRoots.API.Shared.Domain.Repositories;
using ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public abstract class BaseRepository<TEntity>(ArtisanRootsContext context) : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly ArtisanRootsContext Context = context;

    public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

    public async Task<TEntity?> FindByIdAsync(int id) => await Context.Set<TEntity>().FindAsync(id);

    public async Task<IEnumerable<TEntity>> ListAsync() => await Context.Set<TEntity>().ToListAsync();

    public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);

}

