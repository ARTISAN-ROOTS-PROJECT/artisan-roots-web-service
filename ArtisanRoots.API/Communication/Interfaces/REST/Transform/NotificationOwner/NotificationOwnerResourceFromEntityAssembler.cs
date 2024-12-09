using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Interfaces.REST.Resources.NotificationOwner;

namespace ArtisanRoots.API.Communication.Interfaces.REST.Transform.NotificationOwner;

public static class NotificationOwnerResourceFromEntityAssembler
{
    public static NotificationOwnerResource ToResourceFromEntity(Domain.Model.Aggregates.NotificationOwner entity)
    {
        return new NotificationOwnerResource(entity.Id, entity.Title, entity.Content, entity.OwnersId);
    }
}
   
