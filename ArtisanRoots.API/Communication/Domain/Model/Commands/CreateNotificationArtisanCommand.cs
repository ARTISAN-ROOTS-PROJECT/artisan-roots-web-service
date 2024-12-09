namespace ArtisanRoots.API.Communication.Domain.Model.Commands;

public record CreateNotificationArtisanCommand(string Title, string Content, int ArtisansId);

