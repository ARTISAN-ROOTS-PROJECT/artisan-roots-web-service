namespace ArtisanRoots.API.Communication.Domain.Model.Commands;
    
public record CreateNotificationOwnerCommand(string Title, string Content, int OwnersId);

