namespace ArtisanRoots.API.Communication.Interfaces.REST.Resources.NotificationOwner;

public record CreateNotificationOwnerResource(string Title, string Content, int OwnersId);