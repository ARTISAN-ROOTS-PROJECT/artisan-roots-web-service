namespace ArtisanRoots.API.Communication.Interfaces.REST.Resources.NotificationArtisan;
    
public record NotificationArtisanResource(int Id, string? Title, string? Content, int ArtisansId);