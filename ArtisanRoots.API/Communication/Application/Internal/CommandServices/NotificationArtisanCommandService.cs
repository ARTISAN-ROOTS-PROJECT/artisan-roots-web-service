using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Commands;
using ArtisanRoots.API.Communication.Domain.Services.CommandServices;

namespace ArtisanRoots.API.Communication.Application.Internal.CommandServices;

public class NotificationArtisanCommandService : INotificationArtisanCommandService
{
    public async Task<NotificationArtisan?> Handle(CreateNotificationArtisanCommand command)
    {
        if(string.IsNullOrEmpty(command.Title) || string.IsNullOrEmpty(command.Content) || command.ArtisansId == 0)
            
    }
}

