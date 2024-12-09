using ArtisanRoots.API.Shared.Domain.Repositories;
using ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Repositories;

public class UnitOfWork(ArtisanRootsContext context) : IUnitOfWork
{

    public async Task CommitAsync() => await context.SaveChangesAsync();

}

