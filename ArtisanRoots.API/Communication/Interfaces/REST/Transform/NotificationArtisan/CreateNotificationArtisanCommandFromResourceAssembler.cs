using ArtisanRoots.API.Communication.Domain.Model.Commands;
using ArtisanRoots.API.Communication.Interfaces.REST.Resources.NotificationArtisan;

namespace ArtisanRoots.API.Communication.Interfaces.REST.Transform.NotificationArtisan;

public static class CreateNotificationArtisanCommandFromResourceAssembler
{
    public static CreateNotificationArtisanCommand ToCommandFromResorce(CreateNotificationArtisanResource resource)
    {
        return new CreateNotificationArtisanCommand(resource.Title, resource.Content, resource.ArtisansId);
    }
}
