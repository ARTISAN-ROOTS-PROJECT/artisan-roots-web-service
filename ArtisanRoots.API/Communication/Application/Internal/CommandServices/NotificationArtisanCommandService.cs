using ArtisanRoots.API.Communication.Domain.Model.Aggregates;
using ArtisanRoots.API.Communication.Domain.Model.Commands;
using ArtisanRoots.API.Communication.Domain.Model.Exceptions;
using ArtisanRoots.API.Communication.Domain.Repositories;
using ArtisanRoots.API.Communication.Domain.Services.CommandServices;
using ArtisanRoots.API.Shared.Domain.Repositories;

namespace ArtisanRoots.API.Communication.Application.Internal.CommandServices;

public class NotificationArtisanCommandService(IUnitOfWork unitOfWork, 
    INotificationArtisanRepository notificationArtisanRepository) : INotificationArtisanCommandService
{
    public async Task<NotificationArtisan?> Handle(CreateNotificationArtisanCommand command)
    {
        if (string.IsNullOrEmpty(command.Title) || string.IsNullOrEmpty(command.Content) || command.ArtisansId == 0)
            throw new AnyAttributeCanBeEmptyOrNullException();

        var entity = new NotificationArtisan(command);

        await notificationArtisanRepository.AddAsync(entity);

        await unitOfWork.CommitAsync();

        return entity;
    }
}

