using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Queries;
using ArtisanRoots.API.Communication.Domain.Repositories;
using ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ArtisanRoots.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ArtisanRoots.API.Communication.Infrastructure.Persistence.EFC.Repositories;

public class NotificationOwnerRepository(ArtisanRootsContext context) : BaseRepository<NotificationOwner>(context), 
    INotificationOwnerRepository
{

}

