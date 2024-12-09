using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Repositories;
using ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArtisanRoots.API.Communication.Infrastructure.Persistence.EFC.Repositories;

public class NotificationArtisanRepository(ArtisanRootsContext context) : BaseRepository<NotificationArtisan>(context), INotificationArtisanRepository
{
    public async Task<IEnumerable<NotificationArtisan>> FindAllAsync()
        => await Context.Set<NotificationArtisan>().ToListAsync();

}

