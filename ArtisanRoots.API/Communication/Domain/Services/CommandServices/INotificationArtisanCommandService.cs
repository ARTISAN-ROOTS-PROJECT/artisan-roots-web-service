using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Commands;

namespace ArtisanRoots.API.Communication.Domain.Services.CommandServices;

public interface INotificationArtisanCommandService
{
    Task<NotificationArtisan?> Handle(CreateNotificationArtisanCommand command);

}
