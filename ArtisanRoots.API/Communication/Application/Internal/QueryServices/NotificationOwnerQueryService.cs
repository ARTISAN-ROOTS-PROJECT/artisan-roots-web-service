using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Queries;
using ArtisanRoots.API.Communication.Domain.Repositories;
using ArtisanRoots.API.Communication.Domain.Services.QueryServices;

namespace ArtisanRoots.API.Communication.Application.Internal.QueryServices;

public class NotificationOwnerQueryService(INotificationOwnerRepository notificationOwnerRepository) : INotificationOwnerQueryService
{
    public async Task<IEnumerable<NotificationOwner>> Handle(GetAllNotificationsQuery query)
    => await notificationOwnerRepository.ListAsync();

}

