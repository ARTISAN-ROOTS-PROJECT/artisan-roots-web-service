using ArtisanRoots.API.Communication.Domain.Model.Commands;
using ArtisanRoots.API.IAM.Domain.Model.Aggregates;

namespace ArtisanRoots.API.Communication.Domain.Model.Aggregates;

public partial class NotificationArtisan
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public string? Content { get; set; }

    public int? ArtisansId { get; set; }

    public virtual Artisan? Artisans { get; set; }

    public NotificationArtisan()
    {

    }

    public NotificationArtisan(CreateNotificationArtisanCommand command)
    {
        Title = command.Title;
        Content = command.Content;
        ArtisansId = command.ArtisansId;
    }

}