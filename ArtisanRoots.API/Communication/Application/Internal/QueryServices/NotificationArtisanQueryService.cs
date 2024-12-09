using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Queries;
using ArtisanRoots.API.Communication.Domain.Repositories;
using ArtisanRoots.API.Communication.Domain.Services.QueryServices;

namespace ArtisanRoots.API.Communication.Application.Internal.QueryServices;

public class NotificationArtisanQueryService(INotificationArtisanRepository notificationArtisanRepository) : INotificationArtisanQueryService
{
    public async Task<IEnumerable<NotificationArtisan>> Handle(GetAllNotificationsQuery query)
    => await notificationArtisanRepository.ListAsync();

}