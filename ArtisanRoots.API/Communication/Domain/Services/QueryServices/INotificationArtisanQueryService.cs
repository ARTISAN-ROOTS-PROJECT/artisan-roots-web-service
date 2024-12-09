using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Queries;

namespace ArtisanRoots.API.Communication.Domain.Services.QueryServices;

public interface INotificationArtisanQueryService
{
    Task<IEnumerable<NotificationArtisan>> Handle(GetAllNotificationsQuery query);

}

