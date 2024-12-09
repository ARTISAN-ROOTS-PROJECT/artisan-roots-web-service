using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Interfaces.REST.Resources.NotificationArtisan;

namespace ArtisanRoots.API.Communication.Interfaces.REST.Transform.NotificationArtisan;

public static class NotificationArtisanResourceFromEntityAssembler
{
    public static NotificationArtisanResource ToResourceFromEntity(Domain.Model.Aggregates.NotificationArtisan entity)
    {
        return new NotificationArtisanResource(entity.Id, entity.Title, entity.Content, entity.ArtisansId);
    }
}

