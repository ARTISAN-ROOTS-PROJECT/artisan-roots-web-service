using ArtisanRoots.API.Communication.Domain.Model.Commands;
using ArtisanRoots.API.IAM.Domain.Model.Aggregates;

namespace ArtisanRoots.API.Communication.Domain.Model.Aggregates;

public partial class NotificationOwner
{
    public int Id { get; private set; }

    public string? Title { get; private set; }

    public string? Content { get; private set; }

    public int? OwnersId { get; private set; }

    public virtual Owner? Owners { get; set; } 
    
    public NotificationOwner()
    {

    }

    public NotificationOwner(CreateNotificationOwnerCommand command)
    {
        Title = command.Title;
        Content = command.Content;
        OwnersId = command.OwnersId;
    }

}

