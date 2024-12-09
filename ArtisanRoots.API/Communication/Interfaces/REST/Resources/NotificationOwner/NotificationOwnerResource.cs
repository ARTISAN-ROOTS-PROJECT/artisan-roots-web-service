namespace ArtisanRoots.API.Communication.Interfaces.REST.Resources.NotificationOwner;

public record NotificationOwnerResource(int Id, string? Title, string? Content, int ArtisansId);