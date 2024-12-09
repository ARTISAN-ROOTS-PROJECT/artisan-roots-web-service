using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Shared.Domain.Repositories;

namespace ArtisanRoots.API.Communication.Domain.Repositories;
    
public interface INotificationArtisanRepository : IBaseRepository<NotificationArtisan>
{
    Task<IEnumerable<NotificationArtisan>> FindAllAsync();

}