using ArtisanRoots.API.Communication.Domain.Model.Commands;
using ArtisanRoots.API.Communication.Interfaces.REST.Resources.NotificationOwner;

namespace ArtisanRoots.API.Communication.Interfaces.REST.Transform.NotificationOwner
{
    public static class CreateNotificationOwnerCommandFromResourceAssembler
    {
        public static CreateNotificationOwnerCommand ToCommandFromResource(CreateNotificationOwnerResource resource)
        {
            return new(resource.Title, resource.Content, resource.OwnersId);
        }
    }
}
