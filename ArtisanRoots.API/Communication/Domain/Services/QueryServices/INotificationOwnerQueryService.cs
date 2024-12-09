using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Queries;

namespace ArtisanRoots.API.Communication.Domain.Services.QueryServices;

public interface INotificationOwnerQueryService
{
    Task<IEnumerable<NotificationOwner>> Handle(GetAllNotificationsQuery query);

}
